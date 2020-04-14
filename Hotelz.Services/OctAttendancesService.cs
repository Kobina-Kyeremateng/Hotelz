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
    public class OctAttendancesService
    {
        private static readonly IContainer _container;

        static OctAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OctAttendancesRepository>().As<IOctAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IOctAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<OctAttendances> GetList()
        {
            return _container.Resolve<IOctAttendancesRepository>().GetList();
        }

        public static OctAttendances Save(OctAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IOctAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IOctAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static OctAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IOctAttendancesRepository>().Find(AttendanceID);
        }
    }
}
