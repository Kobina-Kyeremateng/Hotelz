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
    public class LeaveService
    {
        private static readonly IContainer _container;

        static LeaveService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LeaveRepository>().As<ILeaveRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int LeaveID)
        {
            return _container.Resolve<ILeaveRepository>().Delete(LeaveID);
        }

        public static List<Leave> GetList()
        {
            return _container.Resolve<ILeaveRepository>().GetList();
        }

        public static Leave Save(Leave obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.LeaveID = _container.Resolve<ILeaveRepository>().Insert(obj);
            else
                _container.Resolve<ILeaveRepository>().Update(obj, obj.LeaveID);
            return obj;
        }

        public static Leave Find(int LeaveID)
        {
            return _container.Resolve<ILeaveRepository>().Find(LeaveID);
        }
    }
}
