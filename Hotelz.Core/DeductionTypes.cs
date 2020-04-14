using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public class DeductionTypes
    {
        public int DeductionTypeID { get; set; }

        public string DeductionCode { get; set; }

        public string DeductionName { get; set; }

        public int TaxID { get; set; }

        public decimal DeductionPercentage { get; set; }

        public decimal Amount { get; set; }

        public byte IsActive { get; set; }

        public int EmployeeID { get; set; }

        public DateTime InputDate { get; set; }

        public byte IsBeforeTax { get; set; }
    }
}
