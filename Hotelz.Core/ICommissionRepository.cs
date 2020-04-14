using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface ICommissionRepository
    {
        List<Commission> GetList();

        int Insert(Commission obj);

        bool Update(Commission obj, int CommissionID);

        bool Delete(int CommissionID);

        Commission Find(int CommissionID);
    }
}
