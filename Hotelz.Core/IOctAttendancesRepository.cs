using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface IOctAttendancesRepository
    {
        List<OctAttendances> GetList();

        int Insert(OctAttendances obj);

        bool Update(OctAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        OctAttendances Find(int AttendanceID);
    }
}
