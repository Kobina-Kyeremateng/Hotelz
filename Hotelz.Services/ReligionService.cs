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
    public class ReligionService
    {
        private static readonly IContainer _container;

        static ReligionService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReligionRepository>().As<IReligionRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int ReligionID)
        {
            return _container.Resolve<IReligionRepository>().Delete(ReligionID);
        }

        public static List<Religion> GetList()
        {
            return _container.Resolve<IReligionRepository>().GetList();
        }

        public static Religion Save(Religion obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.ReligionID = _container.Resolve<IReligionRepository>().Insert(obj);
            else
                _container.Resolve<IReligionRepository>().Update(obj, obj.ReligionID);
            return obj;
        }

        public static Religion Find(int ReligionID)
        {
            return _container.Resolve<IReligionRepository>().Find(ReligionID);
        }
    }
}
