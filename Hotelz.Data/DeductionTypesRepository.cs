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
    public class DeductionTypesRepository : IDeductionTypesRepository
    {
        public bool Delete(int DeductionTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@DeductionTypesID", value: DeductionTypeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_DeductionTypes", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public DeductionTypes Find(int DeductionTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@DeductionTypeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: DeductionTypeID);
                return db.QuerySingle<DeductionTypes>("proc_DeductionTypes", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<DeductionTypes> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<DeductionTypes>("proc_DeductionTypes", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(DeductionTypes obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@DeductionTypesID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                   obj.Amount,
                   obj.DeductionCode,
                   obj.DeductionName,
                   obj.DeductionPercentage,
                   obj.EmployeeID
                });
                db.Execute("proc_DeductionTypes", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@DeductionTypesID");
            }
        }

        public bool Update(DeductionTypes obj, int DeductionTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@DeductionTypesID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: DeductionTypeID);
                p.AddDynamicParams(new
                {
                    obj.Amount,
                    obj.DeductionCode,
                    obj.DeductionName,
                    obj.DeductionPercentage,
                    obj.EmployeeID
                });
                var result = db.Execute("proc_DeductionTypes", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
