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
    public class SeptAttendancesService
    {
        private static readonly IContainer _container;

        static SeptAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SeptAttendancesRepository>().As<ISeptAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<ISeptAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<SeptAttendances> GetList()
        {
            return _container.Resolve<ISeptAttendancesRepository>().GetList();
        }

        public static SeptAttendances Save(SeptAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<ISeptAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<ISeptAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static SeptAttendances Find(int AttendanceID)
        {
            return _container.Resolve<ISeptAttendancesRepository>().Find(AttendanceID);
        }
    }
}
