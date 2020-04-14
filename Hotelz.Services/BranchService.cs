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
    public class BranchService
    {
        private static readonly IContainer _container;

        static BranchService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BranchRepository>().As<IBranchRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int BranchID)
        {
            return _container.Resolve<IBranchRepository>().Delete(BranchID);
        }

        public static List<Branch> GetList()
        {
            return _container.Resolve<IBranchRepository>().GetList();
        }

        public static Branch Save(Branch obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.BranchID = _container.Resolve<IBranchRepository>().Insert(obj);
            else
                _container.Resolve<IBranchRepository>().Update(obj, obj.BranchID);
            return obj;
        }

        public static Branch Find(int BranchID)
        {
            return _container.Resolve<IBranchRepository>().Find(BranchID);
        }
    }
}
