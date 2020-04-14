using Dapper;
using Hotelz.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class TaxRepository : ITaxRepository
    {
        public bool Delete(int TaxID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@TaxID", value: TaxID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Tax", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Tax Find(int TaxID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@TaxID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: TaxID);
                return db.QuerySingle<Tax>("proc_Tax", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Tax> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Tax>("proc_Tax", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Tax obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@TaxID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.Description,
                    obj.Rate
                });
                db.Execute("proc_Tax", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@TaxID");
            }
        }

        public bool Update(Tax obj, int TaxID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@TaxID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: TaxID);
                p.AddDynamicParams(new
                {
                    obj.Description,
                    obj.Rate
                });
                var result = db.Execute("proc_Tax", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }

        }
    }
}
