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
    public class TaxService
    {
        private static readonly IContainer _container;

        static TaxService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TaxRepository>().As<ITaxRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int TaxID)
        {
            return _container.Resolve<ITaxRepository>().Delete(TaxID);
        }

        public static List<Tax> GetList()
        {
            return _container.Resolve<ITaxRepository>().GetList();
        }

        public static Tax Save(Tax obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.TaxID = _container.Resolve<ITaxRepository>().Insert(obj);
            else
                _container.Resolve<ITaxRepository>().Update(obj, obj.TaxID);
            return obj;
        }

        public static Tax Find(int TaxID)
        {
            return _container.Resolve<ITaxRepository>().Find(TaxID);
        }
    }
}
