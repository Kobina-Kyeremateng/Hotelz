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
    public class BankBranchService
    {
        private static readonly IContainer _container;

        static BankBranchService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BankBranchRepository>().As<IBankBranchRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int BankBranchID)
        {
            return _container.Resolve<IBankBranchRepository>().Delete(BankBranchID);
        }

        public static List<BankBranch> GetList()
        {
            return _container.Resolve<IBankBranchRepository>().GetList();
        }

        public static BankBranch Save(BankBranch obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.BankBranchID = _container.Resolve<IBankBranchRepository>().Insert(obj);
            else
                _container.Resolve<IBankBranchRepository>().Update(obj, obj.BankBranchID);
            return obj;
        }

        public static BankBranch Find(int BankBranchID)
        {
            return _container.Resolve<IBankBranchRepository>().Find(BankBranchID);
        }
    }
}
