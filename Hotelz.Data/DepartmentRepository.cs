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
    public class DepartmentRepository : IDepartmentRepository
    {
        public bool Delete(int DepartmentID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@DepartmentID", value: DepartmentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Department Find(int DepartmentID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@DepartmentID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: DepartmentID);
                return db.QuerySingle<Department>("proc_Department", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<Department> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Department>("proc_Department", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Department obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@DepartmentID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.DepartmentName
                });
                db.Execute("proc_Department", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@DepartmentID");
            }
        }

        public bool Update(Department obj, int DepartmentID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@DepartmentID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: DepartmentID);
                p.AddDynamicParams(new
                {
                    obj.DepartmentName
                });
                var result = db.Execute("proc_Department", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
