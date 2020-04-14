using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
   public interface IQualificationRepository
    {
        List<Qualification> GetList();

        int Insert(Qualification obj);

        bool Update(Qualification obj, int QualificationID);

        bool Delete(int QualificationID);

        Qualification Find(int QualificationID);
    }
}
