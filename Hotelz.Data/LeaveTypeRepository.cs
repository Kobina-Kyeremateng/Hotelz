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
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        public bool Delete(int LeaveTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@LeaveTypeID", value: LeaveTypeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_LeaveType", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public LeaveType Find(int LeaveTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@LeaveTypeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: LeaveTypeID);
                return db.QuerySingle<LeaveType>("proc_LeaveType", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<LeaveType> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<LeaveType>("proc_LeaveType", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(LeaveType obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@LeaveTypeID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.LeaveTypeName
                });
                db.Execute("proc_LeaveType", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@LeaveTypeID");
            }
        }

        public bool Update(LeaveType obj, int LeaveTypeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@LeaveTypeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: LeaveTypeID);
                p.AddDynamicParams(new
                {
                    obj.LeaveTypeName
                });
                var result = db.Execute("proc_LeaveType", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
