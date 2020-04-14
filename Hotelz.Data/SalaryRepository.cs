using Dapper;
using Hotelz.Core;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class SalaryRepository : ISalaryRepository
    {
        public bool Delete(int SalaryID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@SalaryID", value: SalaryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Salary", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Salary Find(int SalaryID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@SalaryID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: SalaryID);
                return db.QuerySingle<Salary>("proc_Salary", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Salary> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Salary>("proc_Salary", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Salary obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@SalaryID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.Amount,
                    obj.Category
                });
                db.Execute("proc_Salary", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@SalaryID");
            }
        }

        public bool Update(Salary obj, int SalaryID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@SalaryID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: SalaryID);
                p.AddDynamicParams(new
                {
                    obj.Amount,
                    obj.Category
                });
                var result = db.Execute("proc_Salary", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
