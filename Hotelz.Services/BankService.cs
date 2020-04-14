using Autofac;
using Hotelz.Core;
using Hotelz.Data;
using System.Collections.Generic;

namespace Hotelz.Service
{
    public class BankService
    {
        private static readonly IContainer _container;

        static BankService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BankRepository>().As<IBankRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int BankID)
        {
            return _container.Resolve<IBankRepository>().Delete(BankID);
        }

        public static List<Bank> GetList()
        {
            return _container.Resolve<IBankRepository>().GetList();
        }

        public static Bank Save(Bank obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.BankID = _container.Resolve<IBankRepository>().Insert(obj);
            else 
                _container.Resolve<IBankRepository>().Update(obj, obj.BankID);
            return obj;
        }

        public static Bank Find(int BankID)
        {
            return _container.Resolve<IBankRepository>().Find(BankID);
        }
    }
}
