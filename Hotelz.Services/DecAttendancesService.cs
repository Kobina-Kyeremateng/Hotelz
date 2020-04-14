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
    public class DecAttendancesService
    {
        private static readonly IContainer _container;

        static DecAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DecAttendancesRepository>().As<IDecAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IDecAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<DecAttendances> GetList()
        {
            return _container.Resolve<IDecAttendancesRepository>().GetList();
        }

        public static DecAttendances Save(DecAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IDecAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IDecAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static DecAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IDecAttendancesRepository>().Find(AttendanceID);
        }
    }
}
