using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface ISalaryRepository
    {
        List<Salary> GetList();

        int Insert(Salary obj);

        bool Update(Salary obj, int SalaryID);

        bool Delete(int SalaryID);

        Salary Find(int SalaryID);
    }
}
