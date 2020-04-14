using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public class Employees
    {
        public int EmployeeID { get; set; }

        public string EmployeeNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherNames { get; set; }

        public Prefix Prefix { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int MaritalStatusID { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public int QualificationID { get; set; }

        public int EmploymentTypeID { get; set; }

        public DateTime HireDate { get; set; }

        public int JobID { get; set; }

        public int DepartmentID { get; set; }

        public int HodID { get; set; }

        public int CommissionID { get; set; } 

        public int OvertimeID { get; set; }

        public int SalaryID { get; set; }

        public string AccountNumber { get; set; }

        public int BankID { get; set; }

        public int BankBranchID { get; set; }

        public string SocialSecurity { get; set; }

        public string TinNumber { get; set; }

        public int ReligionID { get; set; }

        public int NationalityID { get; set; }

        public string Photo { get; set; }

        public int roleID { get; set; }
    }


    public enum Gender
    {
        Male = 1,
        Female,
        Other
    }

    //public enum MaritalStatus
    //{
    //    Single = 1,
    //    Married,
    //    Divorced,
    //    Separated,
    //    Widowed
    //}

    public enum Prefix
    {
        Mr = 1,
        Mrs,
        Miss,
        Dr,
        Eng,
        Prof,
        Deacon,
        Deaconess,
        Elder,
        Pastor,
        Rev,
        Bishop,
        Apostle,
        ArchBishop
    }
}
