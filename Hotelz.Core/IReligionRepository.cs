using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface IReligionRepository
    {
        List<Religion> GetList();

        int Insert(Religion obj);

        bool Update(Religion obj, int ReligionID);

        bool Delete(int ReligionID);

        Religion Find(int ReligionID);
    }
}
