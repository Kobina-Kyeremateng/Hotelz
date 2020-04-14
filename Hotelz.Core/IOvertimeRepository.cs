using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface IOvertimeRepository
    {
        List<Overtime> GetList();

        int Insert(Overtime obj);

        bool Update(Overtime obj, int OvertimeID);

        bool Delete(int OvertimeID);

        Overtime Find(int OvertimeID);
    }
}
