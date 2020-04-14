using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface ISeptAttendancesRepository
    {
        List<SeptAttendances> GetList();

        int Insert(SeptAttendances obj);

        bool Update(SeptAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        SeptAttendances Find(int AttendanceID);
    }
}
