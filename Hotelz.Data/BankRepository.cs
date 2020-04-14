using Dapper;
using Hotelz.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class BankRepository : IBankRepository
    {
        public bool Delete(int BankID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BankID", value: BankID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Bank", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Bank Find(int BankID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@BankID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: BankID);
                return db.QuerySingle<Bank>("proc_Bank", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Bank> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Bank>("proc_Bank", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Bank obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@BankID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.BankName
                });
                db.Execute("proc_Bank", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@BankID");
            }
        }

        public bool Update(Bank obj, int BankID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@BankID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: BankID);
                p.AddDynamicParams(new
                {
                    obj.BankName
                });
                var result = db.Execute("proc_Bank", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
