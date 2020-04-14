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
    public class JanAttendancesService
    {
        private static readonly IContainer _container;

        static JanAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JanAttendancesRepository>().As<IJanAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IJanAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<JanAttendances> GetList()
        {
            return _container.Resolve<IJanAttendancesRepository>().GetList();
        }

        public static JanAttendances Save(JanAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IJanAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IJanAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static JanAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IJanAttendancesRepository>().Find(AttendanceID);
        }
    }
}
