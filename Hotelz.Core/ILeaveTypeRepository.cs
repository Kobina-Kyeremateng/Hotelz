using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface ILeaveTypeRepository
    {
        List<LeaveType> GetList();

        int Insert(LeaveType obj);

        bool Update(LeaveType obj, int LeaveTypeID);

        bool Delete(int LeaveTypeID);

        LeaveType Find(int LeaveTypeID);
    }
}
