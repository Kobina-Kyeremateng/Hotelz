using Dapper;
using Hotelz.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class ReligionRepository : IReligionRepository
    {
        public bool Delete(int ReligionID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@ReligionID", value: ReligionID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Religion", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Religion Find(int ReligionID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@ReligionID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: ReligionID);
                return db.QuerySingle<Religion>("proc_Religion", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Religion> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Religion>("proc_Religion", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Religion obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@ReligionID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.ReligionName
                });
                db.Execute("proc_Religion", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@ReligionID");
            }
        }

        public bool Update(Religion obj, int ReligionID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@ReligionID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: ReligionID);
                p.AddDynamicParams(new
                {
                    obj.ReligionName
                });
                var result = db.Execute("proc_Religion", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
