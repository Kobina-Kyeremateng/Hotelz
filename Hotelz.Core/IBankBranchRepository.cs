using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IBankBranchRepository
    {
        List<BankBranch> GetList();

        int Insert(BankBranch obj);

        bool Update(BankBranch obj, int BankBranchID);

        bool Delete(int BankBranchID);

        BankBranch Find(int BankBranchID);
    }
}
