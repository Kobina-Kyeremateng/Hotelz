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
    public class SalaryService
    {
        private static readonly IContainer _container;

        static SalaryService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SalaryRepository>().As<ISalaryRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int SalaryID)
        {
            return _container.Resolve<ISalaryRepository>().Delete(SalaryID);
        }

        public static List<Salary> GetList()
        {
            return _container.Resolve<ISalaryRepository>().GetList();
        }

        public static Salary Save(Salary obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.SalaryID = _container.Resolve<ISalaryRepository>().Insert(obj);
            else
                _container.Resolve<ISalaryRepository>().Update(obj, obj.SalaryID);
            return obj;
        }

        public static Salary Find(int SalaryID)
        {
            return _container.Resolve<ISalaryRepository>().Find(SalaryID);
        }
    }
}
