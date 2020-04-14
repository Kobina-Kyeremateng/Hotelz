using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IAprAttendancesRepository
    {
        List<AprAttendances> GetList();

        int Insert(AprAttendances obj);

        bool Update(AprAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        AprAttendances Find(int AttendanceID);
    }
}
