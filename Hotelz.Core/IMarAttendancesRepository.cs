using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface IMarAttendancesRepository
    {
        List<MarAttendances> GetList();

        int Insert(MarAttendances obj);

        bool Update(MarAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        MarAttendances Find(int AttendanceID);
    }
}
