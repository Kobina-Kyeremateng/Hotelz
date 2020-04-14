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
    public class JunAttendancesService
    {
        private static readonly IContainer _container;

        static JunAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JunAttendancesRepository>().As<IJunAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IJunAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<JunAttendances> GetList()
        {
            return _container.Resolve<IJunAttendancesRepository>().GetList();
        }

        public static JunAttendances Save(JunAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IJunAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IJunAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static JunAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IJunAttendancesRepository>().Find(AttendanceID);
        }
    }
}
