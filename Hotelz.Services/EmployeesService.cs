using Autofac;
using Hotelz.Data;
using Hotelz.Core;
using System.Collections.Generic;

namespace Hotelz.Service
{
    public class EmployeesService
    {
        private static readonly IContainer _container;

        static EmployeesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmployeesRepository>().As<IEmployeesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int EmployeeID)
        {
            return _container.Resolve<IEmployeesRepository>().Delete(EmployeeID);
        }

        public static List<Employees> GetList()
        {
            return _container.Resolve<IEmployeesRepository>().GetList();
        }

        public static Employees Save(Employees obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.EmployeeID = _container.Resolve<IEmployeesRepository>().Insert(obj);
            else
                _container.Resolve<IEmployeesRepository>().Update(obj, obj.EmployeeID);
            return obj;
        }

        public static Employees Find(int EmployeeID)
        {
            return _container.Resolve<IEmployeesRepository>().Find(EmployeeID);
        }
    }
}
