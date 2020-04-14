using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface INovAttendancesRepository
    {
        List<NovAttendances> GetList();

        int Insert(NovAttendances obj);

        bool Update(NovAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        NovAttendances Find(int AttendanceID);
    }
}
