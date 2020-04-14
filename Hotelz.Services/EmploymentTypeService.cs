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
    public class EmploymentTypeService
    {
        private static readonly IContainer _container;

        static EmploymentTypeService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmploymentTypeRepository>().As<IEmploymentTypeRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int EmploymentTypeID)
        {
            return _container.Resolve<IEmploymentTypeRepository>().Delete(EmploymentTypeID);
        }

        public static List<EmploymentType> GetList()
        {
            return _container.Resolve<IEmploymentTypeRepository>().GetList();
        }

        public static EmploymentType Save(EmploymentType obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.EmploymentTypeID = _container.Resolve<IEmploymentTypeRepository>().Insert(obj);
            else
                _container.Resolve<IEmploymentTypeRepository>().Update(obj, obj.EmploymentTypeID);
            return obj;
        }

        public static EmploymentType Find(int EmploymentTypeID)
        {
            return _container.Resolve<IEmploymentTypeRepository>().Find(EmploymentTypeID);
        }
    }
}
