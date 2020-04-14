using Autofac;
using Hotelz.Core;
using Hotelz.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Service
{
    public class RoleService
    {
        private static readonly IContainer _container;

        static RoleService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int roleID)
        {
            return _container.Resolve<RoleRepository>().Delete(roleID);
        }

        public static List<Roles> GetList()
        {
            return _container.Resolve<IRoleRepository>().GetList();
        }

        public static Roles Save(Roles obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.roleID = _container.Resolve<IRoleRepository>().Insert(obj);
            else
                _container.Resolve<IRoleRepository>().Update(obj, obj.roleID);
            return obj;
        }

        public static Roles Find(int roleID)
        {
            return _container.Resolve<IRoleRepository>().Find(roleID);
        }
    }
}
