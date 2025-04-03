using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Parcial2.Clases;


namespace Parcial2.Controllers
{
    [RoutePrefix ("api/CargarFotos")]
    public class CargaFotosController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> CargarArchivo(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsCargaFotos upload = new clsCargaFotos();
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            upload.request = request;
            return await upload.GrabarArchivo(false);
        }
        [HttpGet]
        public HttpResponseMessage LeerArchivo(string NombreArchivo)
        {
            clsCargaFotos upload = new clsCargaFotos();
            return upload.LeerArchivo(NombreArchivo);
        }
        [HttpPut]
        public async Task<HttpResponseMessage> Actualizar(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsCargaFotos upload = new clsCargaFotos();
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            upload.request = request;
            return await upload.GrabarArchivo(true);
        }
    }
}