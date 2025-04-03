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
    [RoutePrefix ("api/FotoPrenda")]
    public class FotoPrendaController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<FotoPrenda> ConsultarTodos()
        {
            clsFotoPrenda ftPrenda = new clsFotoPrenda();
            return ftPrenda.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarxId")]
        public List<FotoPrenda> ConsultarxId(int IdPrenda)
        {
            clsFotoPrenda ftPrenda = new clsFotoPrenda();
            return ftPrenda.ConsultarFotosxPrenda(IdPrenda);
        }


        [HttpPost]
        [Route("Insertar")]
        public string InsertarFotoPrenda([FromBody] FotoPrenda ftprenda)
        {
            clsFotoPrenda ftpre = new clsFotoPrenda();
            ftpre.ftprenda = ftprenda;
            return ftpre.InsertarFotoPrenda();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] FotoPrenda ftprenda)
        {
            clsFotoPrenda ftpre = new clsFotoPrenda();
            ftpre.ftprenda = ftprenda;
            return ftpre.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarXPrenda")]
        public string EliminarXDocumento(int IdPrenda)
        {
            clsFotoPrenda ftpre = new clsFotoPrenda();
            return ftpre.Eliminar(IdPrenda);
        }
    }
}