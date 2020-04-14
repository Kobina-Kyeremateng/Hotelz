using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz.Core
{
    public interface IDeductionTypesRepository
    {
        List<DeductionTypes> GetList();

        int Insert(DeductionTypes obj);

        bool Update(DeductionTypes obj, int DeductionTypeID);

        bool Delete(int DeductionTypeID);

        DeductionTypes Find(int DeductionTypeID);

    }
}
