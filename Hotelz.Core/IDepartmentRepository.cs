using System.Collections.Generic;

namespace Hotelz.Core
{
    public interface IDepartmentRepository
    {
        //List<Department> GetList(bool? isArchived);

        List<Department> GetList();

        int Insert(Department obj);

        bool Update(Department obj, int DepartmentID);

        bool Delete(int DepartmentID);

        Department Find(int DepartmentID);
    }
}
