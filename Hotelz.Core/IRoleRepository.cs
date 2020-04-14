using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz
{
    public interface IRoleRepository
    {
        List<Roles> GetList();

        int Insert(Roles obj);

        bool Update(Roles obj, int roleID);

        bool Delete(int roleID);

        Roles Find(int roleID);
    }
}
