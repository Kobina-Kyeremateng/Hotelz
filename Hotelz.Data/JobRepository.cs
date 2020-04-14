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
    public class JobRepository : IJobRepository
    {
        public bool Delete(int JobID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@JobID", value: JobID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Job", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Job Find(int JobID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@JobID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: JobID);
                return db.QuerySingle<Job>("proc_Job", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Job> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Job>("proc_Job", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Job obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@JobID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.JobName
                });
                db.Execute("proc_Job", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@JobID");
            }
        }

        public bool Update(Job obj, int JobID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@JobID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: JobID);
                p.AddDynamicParams(new
                {
                    obj.JobName
                });
                var result = db.Execute("proc_Job", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
