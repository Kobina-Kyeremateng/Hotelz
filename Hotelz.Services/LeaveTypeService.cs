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
    public class LeaveTypeService
    {
        private static readonly IContainer _container;

        static LeaveTypeService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LeaveTypeRepository>().As<ILeaveTypeRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int LeaveTypeID)
        {
            return _container.Resolve<ILeaveTypeRepository>().Delete(LeaveTypeID);
        }

        public static List<LeaveType> GetList()
        {
            return _container.Resolve<ILeaveTypeRepository>().GetList();
        }

        public static LeaveType Save(LeaveType obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.LeaveTypeID = _container.Resolve<ILeaveTypeRepository>().Insert(obj);
            else
                _container.Resolve<ILeaveTypeRepository>().Update(obj, obj.LeaveTypeID);
            return obj;
        }

        public static LeaveType Find(int LeaveTypeID)
        {
            return _container.Resolve<ILeaveTypeRepository>().Find(LeaveTypeID);
        }
    }
}
