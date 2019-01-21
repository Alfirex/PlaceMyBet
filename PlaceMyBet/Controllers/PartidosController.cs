using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class PartidosController : ApiController
    {
        // GET: api/Partidos
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Partidos/5
        public Partido Get(int id)
        {
            var repo = new Models.PartidoRepository();

            return repo.Retrieve();
        }

        // POST: api/Partidos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Partidos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Partidos/5
        public void Delete(int id)
        {
        }
    }
}
