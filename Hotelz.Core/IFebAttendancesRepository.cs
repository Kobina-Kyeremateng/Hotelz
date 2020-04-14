using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IFebAttendancesRepository
    {
        List<FebAttendances> GetList();

        int Insert(FebAttendances obj);

        bool Update(FebAttendances obj, int AttendanceID);

        bool Delete(int AttendanceID);

        FebAttendances Find(int AttendanceID);
    }
}
