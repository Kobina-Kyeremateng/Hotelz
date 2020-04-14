using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Hotelz.Data
{
    public class RoleRepository : IRoleRepository
    {
        public bool Delete(int roleID)
        {
            //using (IDbConnection db = new SqlConnection(Helper.ConnectionString))
            //{

            //}
            throw new NotImplementedException();
        }

        public Roles Find(int roleID)
        {
            throw new NotImplementedException();
        }

        public List<Roles> GetList()
        {
            throw new NotImplementedException();
        }

        public int Insert(Roles obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Roles obj, int roleID)
        {
            throw new NotImplementedException();
        }
    }
}
