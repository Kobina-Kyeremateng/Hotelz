using Dapper;
using Hotelz.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class OvertimeRepository : IOvertimeRepository
    {
        public bool Delete(int OvertimeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@OvertimeID", value: OvertimeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Overtime", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Overtime Find(int OvertimeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@OvertimeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: OvertimeID);
                return db.QuerySingle<Overtime>("proc_Overtime", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Overtime> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Overtime>("proc_Overtime", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Overtime obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@OvertimeID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.OvertimeName,
                    obj.OvertimeAmount
                });
                db.Execute("proc_Overtime", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@OvertimeID");
            }
        }

        public bool Update(Overtime obj, int OvertimeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@OvertimeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: OvertimeID);
                p.AddDynamicParams(new
                {
                    obj.OvertimeName,
                    obj.OvertimeAmount
                });
                var result = db.Execute("proc_Overtime", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
