using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IJanAttendancesRepository
    {
        List<JanAttendances> GetList();

        int Insert(JanAttendances obj);

        bool Update(JanAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        JanAttendances Find(int AttendanceID);
    }
}
