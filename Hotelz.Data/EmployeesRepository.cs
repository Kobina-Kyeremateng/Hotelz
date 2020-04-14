using Dapper;
using Hotelz.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Hotelz.Data
{
    public class EmployeesRepository: IEmployeesRepository
    {
        public bool Delete(int EmployeeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 4);
                p.Add("@EmployeeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: EmployeeID);
                var result = db.Execute("proc_Employee", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }

        public Employees Find(int EmployeeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 5);
                p.Add("@EmployeeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: EmployeeID);
                return db.QuerySingle<Employees>("proc_Employee", p, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Employees> GetList()
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 2);
                return db.Query<Employees>("proc_Employees", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int Insert(Employees obj)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event",value: 1, dbType: DbType.Int32, direction: ParameterDirection.Input);
                p.Add("@EmployeeID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    obj.AccountNumber,
                    obj.AddressLine1,
                    obj.AddressLine2,
                    obj.BankBranchID,
                    obj.BankID,
                    obj.CommissionID,
                    obj.DateOfBirth,
                    obj.DepartmentID,
                    obj.Email,
                    obj.EmployeeNumber,
                    obj.EmploymentTypeID,
                    obj.FirstName,
                    obj.Gender,
                    obj.HireDate,
                    obj.roleID,
                    obj.JobID,
                    obj.LastName,
                    obj.MaritalStatusID,
                    obj.NationalityID,
                    obj.OtherNames,
                    obj.OvertimeID,
                    obj.PhoneNumber1,
                    obj.PhoneNumber2,
                    obj.Photo,
                    obj.Prefix,
                    obj.QualificationID,
                    obj.ReligionID,
                    obj.SalaryID,
                    obj.SocialSecurity,
                    obj.TinNumber
                });
                db.Execute("proc_Employee", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@EmployeeID");            
            }
        }

        public bool Update(Employees obj, int EmployeeID)
        {
            using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                var p = new DynamicParameters();
                p.Add("@Event", dbType: DbType.Int32, direction: ParameterDirection.Input, value: 3);
                p.Add("@EmployeeID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: EmployeeID);
                p.AddDynamicParams(new
                {
                    obj.AccountNumber,
                    obj.AddressLine1,
                    obj.AddressLine2,
                    obj.BankBranchID,
                    obj.BankID,
                    obj.CommissionID,
                    obj.DateOfBirth,
                    obj.DepartmentID,
                    obj.Email,
                    obj.EmployeeNumber,
                    obj.EmploymentTypeID,
                    obj.FirstName,
                    obj.Gender,
                    obj.HireDate,
                    obj.roleID,
                    obj.JobID,
                    obj.LastName,
                    obj.MaritalStatusID,
                    obj.NationalityID,
                    obj.OtherNames,
                    obj.OvertimeID,
                    obj.PhoneNumber1,
                    obj.PhoneNumber2,
                    obj.Photo,
                    obj.Prefix,
                    obj.QualificationID,
                    obj.ReligionID,
                    obj.SalaryID,
                    obj.SocialSecurity,
                    obj.TinNumber
                });
                var result = db.Execute("proc_Employee", p, commandType: CommandType.StoredProcedure);
                return result != 0;
            }
        }
    }
}
