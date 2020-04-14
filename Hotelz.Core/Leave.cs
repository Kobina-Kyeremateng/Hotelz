using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public class Leave
    {
        public int LeaveID { get; set; }

        public int EmployeeID { get; set; }

        public int JobID { get; set; }

        public int LeaveTypeID { get; set; }

        public int NoOfDays { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LeaveAddress { get; set; }

        public string PhoneNumber { get; set; }

        public int HodID { get; set; }

        public int HRManager { get; set; }

        public int GenManager { get; set; }
    }
}
