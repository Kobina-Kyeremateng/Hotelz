﻿using Dapper;
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
    public class MarAttendancesRepository : IMarAttendancesRepository
    {
        public bool Delete(int AttendanceID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                var p = new DynamicParameters();
                p.Add("@Event", value: 4, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@AttendanceID", value: AttendanceID, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var result = db.Execute("proc_MarAttendances", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public MarAttendances Find(int AttendanceID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@AttendanceID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: AttendanceID);
                return db.QuerySingle<MarAttendances>("proc_MarAttendances", p, commandType: CommandType.StoredProcedure);
            }

        }

        public List<MarAttendances> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", value: 2, dbType: DbType.Int32, direction: ParameterDirection.Input);
                return db.Query<MarAttendances>("proc_MarAttendances", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(MarAttendances obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@AttendanceID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.EmployeeID,
                    obj.DepartmentID,
                    obj.BranchID,
                    obj.One,
                    obj.Two,
                    obj.Three,
                    obj.Four,
                    obj.Five,
                    obj.Six,
                    obj.Seven,
                    obj.Eight,
                    obj.Nine,
                    obj.Ten,
                    obj.Eleven,
                    obj.Twelve,
                    obj.Thirteen,
                    obj.Fourteen,
                    obj.Fifteen,
                    obj.Sixteen,
                    obj.Seventeen,
                    obj.Eighteen,
                    obj.Nineteen,
                    obj.Twenty,
                    obj.TwentyOne,
                    obj.TwentyTwo,
                    obj.TwentyThree,
                    obj.TwentyFour,
                    obj.TwentyFive,
                    obj.TwentySix,
                    obj.TwentySeven,
                    obj.TwentyEight,
                    obj.TwentyNine,
                    obj.Thirty,
                    obj.ThirtyOne
                });
                db.Execute("proc_MarAttendances", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@AttendanceID");
            }

        }

        public bool Update(MarAttendances obj, int AttendanceID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@AttendanceID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: AttendanceID);
                p.AddDynamicParams(new
                {
                    obj.EmployeeID,
                    obj.DepartmentID,
                    obj.BranchID,
                    obj.One,
                    obj.Two,
                    obj.Three,
                    obj.Four,
                    obj.Five,
                    obj.Six,
                    obj.Seven,
                    obj.Eight,
                    obj.Nine,
                    obj.Ten,
                    obj.Eleven,
                    obj.Twelve,
                    obj.Thirteen,
                    obj.Fourteen,
                    obj.Fifteen,
                    obj.Sixteen,
                    obj.Seventeen,
                    obj.Eighteen,
                    obj.Nineteen,
                    obj.Twenty,
                    obj.TwentyOne,
                    obj.TwentyTwo,
                    obj.TwentyThree,
                    obj.TwentyFour,
                    obj.TwentyFive,
                    obj.TwentySix,
                    obj.TwentySeven,
                    obj.TwentyEight,
                    obj.TwentyNine,
                    obj.Thirty,
                    obj.ThirtyOne
                });
                var result = db.Execute("proc_MarAttendances", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
