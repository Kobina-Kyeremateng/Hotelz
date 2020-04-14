using Autofac;
using Hotelz.Core;
using Hotelz.Data;
using System.Collections.Generic;

namespace Hotelz.Service
{
    public class AugAttendancesService
    {
        private static readonly IContainer _container;

        static AugAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AugAttendancesRepository>().As<IAugAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IAugAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<AugAttendances> GetList()
        {
            return _container.Resolve<IAugAttendancesRepository>().GetList();
        }

        public static AugAttendances Save(AugAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IAugAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IAugAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static AugAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IAugAttendancesRepository>().Find(AttendanceID);
        }
    }
}
