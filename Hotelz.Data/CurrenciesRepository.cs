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
    public class CurrenciesRepository : ICurrencyRepository
    {
        public bool Delete(int CurrencyID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CurrencyID", value: CurrencyID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Currencies", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Currencies Find(int CurrencyID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@CurrencyID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: CurrencyID);
                return db.QuerySingle<Currencies>("proc_Currencies", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<Currencies> Getlist()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Currencies>("proc_Currencies", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Currencies obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@CurrencyID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.CurrencyName,
                    obj.CurrencyCode
                });
                db.Execute("proc_Currencies", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@CurrencyID");
            }
        }

        public bool Update(Currencies obj, int CurencyID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@CurrencyID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: CurencyID);
                p.AddDynamicParams(new
                {
                    obj.CurrencyName,
                    obj.CurrencyCode
                });
                var result = db.Execute("proc_Currencies", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
