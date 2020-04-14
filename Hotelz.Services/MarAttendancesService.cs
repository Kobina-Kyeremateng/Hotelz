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
    public class MarAttendancesService
    {
        private static readonly IContainer _container;

        static MarAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MarAttendancesRepository>().As<IMarAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IMarAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<MarAttendances> GetList()
        {
            return _container.Resolve<IMarAttendancesRepository>().GetList();
        }

        public static MarAttendances Save(MarAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IMarAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IMarAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static MarAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IMarAttendancesRepository>().Find(AttendanceID);
        }
    }
}
