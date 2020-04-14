using Hotelz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IAugAttendancesRepository
    {
        List<AugAttendances> GetList();

        int Insert(AugAttendances obj);

        bool Update(AugAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        AugAttendances Find(int AttendanceID);
    }
}
