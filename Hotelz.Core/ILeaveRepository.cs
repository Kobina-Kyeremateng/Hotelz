using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface ILeaveRepository
    {
        List<Leave> GetList();

        int Insert(Leave obj);

        bool Update(Leave obj, int LeaveID);

        bool Delete(int LeaveID);

        Leave Find(int LeaveID);
    }
}
