using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System;
using Hotelz.Core;

namespace Hotelz.Data
{
    public class NationalityRepository : INationalityRepository
    {
        public bool Delete(int NationalityID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@NationalityID", value: NationalityID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Nationality", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Nationality Find(int NationalityID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@NationalityID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: NationalityID);
                return db.QuerySingle<Nationality>("proc_Nationality", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Nationality> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Nationality>("proc_Nationality", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Nationality obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@NationalityID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.NationalityName
                });
                db.Execute("proc_Nationality", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@NationalityID");
            }
        }

        public bool Update(Nationality obj, int NationalityID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@NationalityID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: NationalityID);
                p.AddDynamicParams(new
                {
                    obj.NationalityName
                });
                var result = db.Execute("proc_Nationality", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
