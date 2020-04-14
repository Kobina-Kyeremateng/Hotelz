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
    public class QualificationService
    {
        private static readonly IContainer _container;

        static QualificationService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<QualificationRepository>().As<IQualificationRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int QualificationID)
        {
            return _container.Resolve<IQualificationRepository>().Delete(QualificationID);
        }

        public static List<Qualification> GetList()
        {
            return _container.Resolve<IQualificationRepository>().GetList();
        }

        public static Qualification Save(Qualification obj, EntityState state)
        {
            if (state == EntityState.Added)
                obj.QualificationID = _container.Resolve<IQualificationRepository>().Insert(obj);
            else
                _container.Resolve<IQualificationRepository>().Update(obj, obj.QualificationID);
            return obj;
        }

        public static Qualification Find(int QualificationID)
        {
            return _container.Resolve<IQualificationRepository>().Find(QualificationID);
        }
    }
}
