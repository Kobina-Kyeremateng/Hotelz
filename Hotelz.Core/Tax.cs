using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public class Tax
    {
        public int TaxID { get; set; }

        public decimal Rate { get; set; }

        public string Description { get; set; }
    }
}
