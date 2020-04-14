using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IBranchRepository
    {
        List<Branch> GetList();

        int Insert(Branch obj);

        bool Update(Branch obj, int BranchID);

        bool Delete(int BranchID);

        Branch Find(int BranchID);
    }
}
