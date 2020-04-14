using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface ITaxRepository
    {
        List<Tax> GetList();

        int Insert(Tax obj);

        bool Update(Tax obj, int TaxID);

        bool Delete(int TaxID);

        Tax Find(int TaxID);
    }
}
