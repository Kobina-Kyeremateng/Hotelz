using System.Collections.Generic;

namespace Hotelz.Core
{
    public interface ICountryRepository
    {
        List<Country> GetList();

        int Insert(Country obj);

        bool Update(Country obj, int CountryID);

        bool Delete(int CountryID);

        Country Find(int CountryID);
    }
}
