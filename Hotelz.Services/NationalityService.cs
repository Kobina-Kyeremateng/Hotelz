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
    public class NationalityService
    {
        private static readonly IContainer _container;

        static NationalityService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NationalityRepository>().As<INationalityRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int NationalityID)
        {
            return _container.Resolve<INationalityRepository>().Delete(NationalityID);
        }

        public static List<Nationality> GetList()
        {
            return _container.Resolve<INationalityRepository>().GetList();
        }

        public static Nationality Save(Nationality obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.NationalityID = _container.Resolve<INationalityRepository>().Insert(obj);
            else
                _container.Resolve<INationalityRepository>().Update(obj, obj.NationalityID);
            return obj;
        }

        public static Nationality Find(int NationalityID)
        {
            return _container.Resolve<INationalityRepository>().Find(NationalityID);
        }
    }
}
