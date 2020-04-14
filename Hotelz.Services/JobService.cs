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
    public class JobService
    {
        private static readonly IContainer _container;

        static JobService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JobRepository>().As<IJobRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int JobID)
        {
            return _container.Resolve<IJobRepository>().Delete(JobID);
        }

        public static List<Job> GetList()
        {
            return _container.Resolve<IJobRepository>().GetList();
        }

        public static Job Save(Job obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.JobID = _container.Resolve<IJobRepository>().Insert(obj);
            else
                _container.Resolve<IJobRepository>().Update(obj, obj.JobID);
            return obj;
        }

        public static Job Find(int JobID)
        {
            return _container.Resolve<IJobRepository>().Find(JobID);
        }
    }
}
