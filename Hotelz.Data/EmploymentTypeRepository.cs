using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Hotelz.Core;

namespace Hotelz.Data
{
    public class EmploymentTypeRepository : IEmploymentTypeRepository
    {
        public bool Delete(int EmploymentTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@EmploymentTypeID", value: EmploymentTypeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public EmploymentType Find(int EmploymentTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@EmploymentTypeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: EmploymentTypeID);
                return db.QuerySingle<EmploymentType>("proc_EmploymentType", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<EmploymentType> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<EmploymentType>("proc_EmploymentType", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(EmploymentType obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@EmploymentTypeID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.EmploymentTypeName
                });
                db.Execute("proc_EmploymentType", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@EmploymentTypeID");
            }
        }

        public bool Update(EmploymentType obj, int EmploymentTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@EmploymentTypeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: EmploymentTypeID);
                p.AddDynamicParams(new
                {
                    obj.EmploymentTypeName
                });
                var result = db.Execute("proc_EmploymentType", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
