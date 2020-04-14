using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IBankRepository
    {
        List<Bank> GetList();

        int Insert(Bank obj);

        bool Update(Bank obj, int BankID);

        bool Delete(int BankID);

        Bank Find(int BankID);
    }
}
