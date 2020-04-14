using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelz
{
    public interface IBaseEvents
    {
        void Save();

        void AddNew();

        void Edit();

        void Cancel();

        void Delete();
    }
}
