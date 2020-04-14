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
    public class CountryService
    {
        private static readonly IContainer _container;

        static CountryService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int CountryID)
        {
            return _container.Resolve<ICountryRepository>().Delete(CountryID);
        }

        public static List<Country> GetList()
        {
            return _container.Resolve<ICountryRepository>().GetList();
        }

        public static Country Save(Country obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.CountryID = _container.Resolve<ICountryRepository>().Insert(obj);
            else
                _container.Resolve<ICountryRepository>().Update(obj, obj.CountryID);
            return obj;
        }

        public static Country Find(int CountryID)
        {
            return _container.Resolve<ICountryRepository>().Find(CountryID);
        }
    }
}
