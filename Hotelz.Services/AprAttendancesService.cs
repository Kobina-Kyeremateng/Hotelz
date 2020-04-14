using Autofac;
using Hotelz.Core;
using Hotelz.Data;
using System.Collections.Generic;

namespace Hotelz.Service
{
    public class AprAttendancesService
    {
        private static readonly IContainer _container;

        static AprAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AprAttendancesRepository>().As<IAprAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IAprAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<AprAttendances> GetList()
        {
            return _container.Resolve<IAprAttendancesRepository>().GetList();
        }

        public static AprAttendances Save(AprAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IAprAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IAprAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static AprAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IAprAttendancesRepository>().Find(AttendanceID);
        }
    }
}
