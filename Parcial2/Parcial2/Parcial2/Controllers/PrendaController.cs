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
        [Route("ConsultarImagenes")]
        public IQueryable ConsultarImagenes(string idProducto)
        {
            clsPrenda Prenda = new clsPrenda();
            return Prenda.ListarPrendasEImagenesXCliente(idProducto);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Prenda> ConsultarTodos()
        {
            clsPrenda cliente = new clsPrenda();
            return cliente.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxId")]
        public List<Prenda> ConsultarxId(int IdPrenda)
        {
            clsPrenda cliente = new clsPrenda();
            return cliente.ConsultarxId(IdPrenda);
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
