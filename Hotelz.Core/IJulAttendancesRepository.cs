using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IJulAttendancesRepository
    {
        List<JulAttendances> GetList();

        int Insert(JulAttendances obj);

        bool Update(JulAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        JulAttendances Find(int AttendanceID);
    }
}
