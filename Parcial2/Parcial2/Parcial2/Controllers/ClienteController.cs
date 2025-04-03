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
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        [HttpGet]
        [Route("ConsultarClientePrendasYFotos")]
        public IQueryable ConsultarImagenes(string idProducto)
        {
            clsCliente Cliente = new clsCliente();
            return Cliente.ConsultarClientePrendasYFotos(idProducto);
        }
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Cliente> ConsultarTodos()
        {
            clsCliente cliente = new clsCliente();
            return cliente.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxDoc")]
        public List<Cliente> ConsultarxDoc(string Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.ConsultarxDoc(Documento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string InsertarCliente([FromBody] Cliente cliente)
        {
            clsCliente cli = new clsCliente();
            cli.cliente = cliente;
            return cli.InsertarCliente();
        }
    }
}