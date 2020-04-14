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
    public class CountryRepository : ICountryRepository
    {
        public bool Delete(int CountryID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CountryID", value: CountryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Country", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Country Find(int CountryID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@CountryID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: CountryID);
                return db.QuerySingle<Country>("proc_Country", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<Country> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Country>("proc_Country", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Country obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CountryID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.CountryCode,
                    obj.CountryISO,
                    obj.CountryISO2,
                    obj.CountryName,
                    obj.CountryName2,
                    obj.CountryPhoneCode
                });
                db.Execute("proc_Country", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@CountryID");
            }
        }

        public bool Update(Country obj, int CountryID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@CountryID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: CountryID);
                p.AddDynamicParams(new
                {
                    obj.CountryCode,
                    obj.CountryISO,
                    obj.CountryISO2,
                    obj.CountryName,
                    obj.CountryName2,
                    obj.CountryPhoneCode
                });
                var result = db.Execute("proc_Country", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
