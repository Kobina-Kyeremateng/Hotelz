using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IJobRepository
    {
        List<Job> GetList();

        int Insert(Job obj);

        bool Update(Job obj, int JobID);

        bool Delete(int JobID);

        Job Find(int JobID);
    }
}
