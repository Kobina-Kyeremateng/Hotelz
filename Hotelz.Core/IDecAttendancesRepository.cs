using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IDecAttendancesRepository
    {
        List<DecAttendances> GetList();

        int Insert(DecAttendances obj);

        bool Update (DecAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        DecAttendances Find(int AttendanceID);
    }
}
