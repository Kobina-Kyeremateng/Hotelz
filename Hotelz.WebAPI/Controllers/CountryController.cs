using System.Collections.Generic;
using System.Web.Http;
using Autofac;
using Hotelz.Data;
using Hotelz.Core;
using Hotelz.Service;

namespace Hotelz.WebAPI.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryController : ApiController
    {

        private static readonly IContainer _container;

        static CountryController()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            _container = builder.Build();
        }


        // GET: api/Country
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Country/5
        [Route("CountryID={CountryID}")]
        public Country Get(int CountryID)
        {
            //return "value";
            return _container.Resolve<ICountryRepository>().Find(CountryID);
        }

        // POST: api/Country
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Country/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Country/5
        public void Delete(int id)
        {
        }
    }
}
