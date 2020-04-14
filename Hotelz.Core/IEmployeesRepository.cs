using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IEmployeesRepository
    {
        List<Employees> GetList();

        int Insert(Employees obj);

        bool Update(Employees obj, int EmployeeID);

        bool Delete(int EmployeeID);

        Employees Find(int EmployeeID);
    }
}
