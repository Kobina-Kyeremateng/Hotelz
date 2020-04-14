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
    public class CommissionRepository : ICommissionRepository
    {
        public bool Delete(int CommissionID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CommissionID", value: CommissionID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Commission Find(int CommissionID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@CommissionID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: CommissionID);
                return db.QuerySingle<Commission>("proc_Commission", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<Commission> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Commission>("proc_Commission", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Commission obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CommissionID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.CommissionName,
                    obj.CommissionAmount
                });
                db.Execute("proc_Commission", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@CommissionID");
            }
        }

        public bool Update(Commission obj, int CommissionID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@CommissionID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: CommissionID);
                p.AddDynamicParams(new
                {
                    obj.CommissionName,
                    obj.CommissionAmount
                });
                var result = db.Execute("proc_Commission", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
