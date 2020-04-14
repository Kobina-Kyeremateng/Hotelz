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
    public class CommissionService
    {
        private static readonly IContainer _container;

        static CommissionService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CommissionRepository>().As<ICommissionRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int CommissionID)
        {
            return _container.Resolve<ICommissionRepository>().Delete(CommissionID);
        }

        public static List<Commission> GetList()
        {
            return _container.Resolve<ICommissionRepository>().GetList();
        }

        public static Commission Save(Commission obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.CommissionID = _container.Resolve<ICommissionRepository>().Insert(obj);
            else
                _container.Resolve<ICommissionRepository>().Update(obj, obj.CommissionID);
            return obj;
        }

        public static Commission Find(int CommissionID)
        {
            return _container.Resolve<ICommissionRepository>().Find(CommissionID);
        }
    }
}
