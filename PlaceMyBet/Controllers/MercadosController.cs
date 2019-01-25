using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<Mercado> Get()
        {
            var repo = new Models.MercadoRepository();

            List<Mercado> mercado = repo.Retrieve();

            return mercado;
        }

        // GET: api/Mercados/5
       public Mercado Get(int id)
        {
            var repo = new MercadoRepository();
            return repo.RetrieveM(id);
        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadoRepository();
            repo.Save(mercado);

        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
