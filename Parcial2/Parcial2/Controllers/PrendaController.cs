using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Parcial2.Clases;
using Parcial2.Models;

namespace Parcial2.Controllers
{
    [RoutePrefix ("api/Prenda")]
    public class PrendaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Prenda> ConsultarTodos()
        {
            clsPrenda prenda = new clsPrenda();
            return prenda.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxId")]
        public List<Prenda> ConsultarxId(int IdPrenda)
        {
            clsPrenda prenda = new clsPrenda();
            return prenda.ConsultarxId(IdPrenda);
        }

        [HttpPost]
        [Route("Insertar")]
        public string InsertarPrenda([FromBody] Prenda prenda)
        {
            clsPrenda pre = new clsPrenda();
            pre.prenda = prenda;
            return pre.InsertarPrenda();
        }
    }

}
