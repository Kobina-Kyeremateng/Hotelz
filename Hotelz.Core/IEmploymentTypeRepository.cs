using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IEmploymentTypeRepository
    {
        List<EmploymentType> GetList();

        int Insert(EmploymentType obj);

        bool Update(EmploymentType obj, int EmploymentTypeID);

        bool Delete(int EmploymentTypeID);

        EmploymentType Find(int EmploymentTypeID);
    }
}
