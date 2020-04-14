using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Hotelz.Core;

namespace Hotelz.Data
{
    public class BranchRepository : IBranchRepository
    {
        public bool Delete(int BranchID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BranchID", value: BranchID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Branch Find(int BranchID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@BranchID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: BranchID);
                return db.QuerySingle<Branch>("proc_Branch", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<Branch> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 2, dbType: DbType.Int32, direction: ParameterDirection.Input);
                return db.Query<Branch>("proc_Branch", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Branch obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BranchID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new {
                    obj.BranchName
                });
                db.Execute("@proc_Branch", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("BranchID");
            }
        }

        public bool Update(Branch obj, int BranchID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BranchID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.BranchName
                });
                var result = db.Execute("@proc_Branch", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
