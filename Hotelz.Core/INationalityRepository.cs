using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface INationalityRepository
    {
        List<Nationality> GetList();

        int Insert(Nationality obj);

        bool Update(Nationality obj, int NationalityID);

        bool Delete(int NationalityID);

        Nationality Find(int NationalityID);
    }
}
