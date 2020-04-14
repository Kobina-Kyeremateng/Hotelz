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
    public class LeaveRepository : ILeaveRepository
    {
        public bool Delete(int LeaveID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@LeaveID", value: LeaveID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_Leave", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Leave Find(int LeaveID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@LeaveID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: LeaveID);
                return db.QuerySingle<Leave>("proc_Leave", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Leave> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Leave>("proc_Leave", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Leave obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@LeaveID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.EmployeeID,
                    obj.EndDate,
                    obj.GenManager,
                    obj.HodID,
                    obj.HRManager,
                    obj.JobID,
                    obj.LeaveAddress,
                    obj.LeaveTypeID,
                    obj.NoOfDays,
                    obj.PhoneNumber,
                    obj.StartDate
                });
                db.Execute("proc_Leave", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@LeaveID");
            }
        }

        public bool Update(Leave obj, int LeaveID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@LeaveID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: LeaveID);
                p.AddDynamicParams(new
                {
                    obj.EmployeeID,
                    obj.EndDate,
                    obj.GenManager,
                    obj.HodID,
                    obj.HRManager,
                    obj.JobID,
                    obj.LeaveAddress,
                    obj.LeaveTypeID,
                    obj.NoOfDays,
                    obj.PhoneNumber,
                    obj.StartDate
                });
                var result = db.Execute("proc_Leave", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
