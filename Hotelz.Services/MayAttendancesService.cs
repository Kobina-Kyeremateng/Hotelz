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
    public class MayAttendancesService
    {
        private static readonly IContainer _container;

        static MayAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MayAttendancesRepository>().As<IMayAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IMayAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<MayAttendances> GetList()
        {
            return _container.Resolve<IMayAttendancesRepository>().GetList();
        }

        public static MayAttendances Save(MayAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IMayAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IMayAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static MayAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IMayAttendancesRepository>().Find(AttendanceID);
        }
    }
}
