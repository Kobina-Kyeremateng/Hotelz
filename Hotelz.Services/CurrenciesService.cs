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
    public class CurrenciesService
    {
        private static readonly IContainer _container;

        static CurrenciesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CurrenciesRepository>().As<ICurrencyRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int CurrencyID)
        {
            return _container.Resolve<ICurrencyRepository>().Delete(CurrencyID);
        }

        public static List<Currencies> GetList()
        {
            return _container.Resolve<ICurrencyRepository>().Getlist();
        }

        public static Currencies Save(Currencies obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.CurrencyID = _container.Resolve<CurrenciesRepository>().Insert(obj);
            else
                _container.Resolve<ICurrencyRepository>().Update(obj, obj.CurrencyID);
            return obj;
        }

        public static Currencies Find(int CurrencyID)
        {
            return _container.Resolve<ICurrencyRepository>().Find(CurrencyID);
        }
    }
}
