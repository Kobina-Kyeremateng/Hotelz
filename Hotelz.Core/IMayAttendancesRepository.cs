using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface IMayAttendancesRepository
    {
        List<MayAttendances> GetList();

        int Insert(MayAttendances obj);

        bool Update(MayAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        MayAttendances Find(int AttendanceID);
    }
}
