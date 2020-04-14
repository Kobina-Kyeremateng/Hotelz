using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface ICurrencyRepository
    {
        List<Currencies> Getlist();

        int Insert(Currencies obj);

        bool Update(Currencies obj, int CurrencyID);

        bool Delete(int CurrencyID);

        Currencies Find(int CurrencyID);
    }
}
