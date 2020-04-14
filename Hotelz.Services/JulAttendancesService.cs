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
    public class JulAttendancesService
    {
        private static readonly IContainer _container;

        static JulAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JulAttendancesRepository>().As<IJulAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IJulAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<JulAttendances> GetList()
        {
            return _container.Resolve<IJulAttendancesRepository>().GetList();
        }

        public static JulAttendances Save(JulAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IJulAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IJulAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static JulAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IJulAttendancesRepository>().Find(AttendanceID);
        }
    }
}
