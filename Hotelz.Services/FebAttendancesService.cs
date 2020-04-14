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
    public class FebAttendancesService
    {
        private static readonly IContainer _container;

        static FebAttendancesService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FebAttendancesRepository>().As<IFebAttendancesRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int AttendanceID)
        {
            return _container.Resolve<IFebAttendancesRepository>().Delete(AttendanceID);
        }

        public static List<FebAttendances> GetList()
        {
            return _container.Resolve<IFebAttendancesRepository>().GetList();
        }

        public static FebAttendances Save(FebAttendances obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.AttendanceID = _container.Resolve<IFebAttendancesRepository>().Insert(obj);
            else
                _container.Resolve<IFebAttendancesRepository>().Update(obj, obj.AttendanceID);
            return obj;
        }

        public static FebAttendances Find(int AttendanceID)
        {
            return _container.Resolve<IFebAttendancesRepository>().Find(AttendanceID);
        }
    }
}
