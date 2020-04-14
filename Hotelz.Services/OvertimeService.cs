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
    public class OvertimeService
    {
        private static readonly IContainer _container;

        static OvertimeService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OvertimeRepository>().As<IOvertimeRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int OvertimeID)
        {
            return _container.Resolve<IOvertimeRepository>().Delete(OvertimeID);
        }

        public static List<Overtime> GetList()
        {
            return _container.Resolve<IOvertimeRepository>().GetList();
        }

        public static Overtime Save(Overtime obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.OvertimeID = _container.Resolve<IOvertimeRepository>().Insert(obj);
            else
                _container.Resolve<IOvertimeRepository>().Update(obj, obj.OvertimeID);
            return obj;
        }

        public static Overtime Find(int OvertimeID)
        {
            return _container.Resolve<IOvertimeRepository>().Find(OvertimeID);
        }
    }
}
