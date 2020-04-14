using Dapper;
using Hotelz.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Data
{
    public class BankBranchRepository : IBankBranchRepository
    {
        public bool Delete(int BankBranchID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BankBranchID", value: BankBranchID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_BankBranch", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public BankBranch Find(int BankBranchID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@BankBranchID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: BankBranchID);
                return db.QuerySingle<BankBranch>("proc_BankBranch", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<BankBranch> GetList()
        {
           using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 2, dbType: DbType.Int32, direction: ParameterDirection.Input);
                return db.Query<BankBranch>("proc_BankBranch", p, commandType: CommandType.StoredProcedure).ToList();

            }
        }

        public int Insert(BankBranch obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BankBranchID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.BankBranchName,
                    obj.BankID
                });
                db.Execute("proc_BankBranch", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("BankBranchID");
            }
        }

        public bool Update(BankBranch obj, int BankBranchID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 3, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BankBranchID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: BankBranchID);
                p.AddDynamicParams(new
                {
                    obj.BankID,
                    obj.BankBranchName
                });
                var result = db.Execute("proc_BankBranch", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
