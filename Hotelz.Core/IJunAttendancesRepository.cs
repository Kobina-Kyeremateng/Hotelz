using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IJunAttendancesRepository
    {
        List<JunAttendances> GetList();

        int Insert(JunAttendances obj);

        bool Update(JunAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        JunAttendances Find(int AttendanceID);
    }
}
