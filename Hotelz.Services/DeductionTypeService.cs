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
    public class DeductionTypeService
    {
        private static readonly IContainer _container;

        static DeductionTypeService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DeductionTypesRepository>().As<IDeductionTypesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int DeductionTypeID)
        {
            return _container.Resolve<IDeductionTypesRepository>().Delete(DeductionTypeID);
        }

        public static List<DeductionTypes> GetList()
        {
            return _container.Resolve<IDeductionTypesRepository>().GetList();
        }

        public static DeductionTypes Save(DeductionTypes obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.DeductionTypeID = _container.Resolve<IDeductionTypesRepository>().Insert(obj);
            else
                _container.Resolve<IDeductionTypesRepository>().Update(obj, obj.DeductionTypeID);
            return obj;
        }

        public static DeductionTypes Find(int DeductionTypeID)
        {
            return _container.Resolve<IDeductionTypesRepository>().Find(DeductionTypeID);
        }
    }
}
