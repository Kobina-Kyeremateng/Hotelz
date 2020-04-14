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
    public class DepartmentService
    {
        private static readonly IContainer _container;

        static DepartmentService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int DepartmentID)
        {
            return _container.Resolve<IDepartmentRepository>().Delete(DepartmentID);
        }

        public static List<Department> GetList()
        {
            return _container.Resolve<IDepartmentRepository>().GetList();
        }

        public static Department Save(Department obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.DepartmentID = _container.Resolve<IDepartmentRepository>().Insert(obj);
            else
                _container.Resolve<IDepartmentRepository>().Update(obj, obj.DepartmentID);
            return obj;
        }

        public static Department Find(int DepartmentID)
        {
            return _container.Resolve<IDepartmentRepository>().Find(DepartmentID);
        }
    }
}
