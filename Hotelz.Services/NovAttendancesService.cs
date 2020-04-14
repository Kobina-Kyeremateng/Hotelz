using Autofac;
using Hotelz.Core;
using Hotelz.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Service
{
    public class NovAttendancesService
    {
        private static readonly Autofac.IContainer _container;

        static NovAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NovAttendancesRepository>().As<INovAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<INovAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<NovAttendances> GetList()
        {
            return _container.Resolve<INovAttendancesRepository>().GetList();
        }

        public static NovAttendances Save(NovAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<INovAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<INovAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static NovAttendances Find(int AttendanceID)
        {
            return _container.Resolve<INovAttendancesRepository>().Find(AttendanceID);
        }
    }
}
