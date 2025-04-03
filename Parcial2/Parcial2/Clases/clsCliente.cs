using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Parcial2.Models;

namespace Parcial2.Clases
{
    public class clsCliente
    {
        private DBExamenEntities DBp = new DBExamenEntities();
        public Cliente cliente { get; set; }

        public List<Cliente> ConsultarTodos()
        {
            return DBp.Clientes
                   .OrderBy(c => c.Nombre)
                   .ToList();
        }

        public List<Cliente> ConsultarxDoc(string Documento)
        {
            return DBp.Clientes
                .Where(c => c.Documento == Documento)
                .ToList();
        }

        public string InsertarCliente()
        {
            
            try
            {
                DBp.Clientes.Add(cliente);
                DBp.SaveChanges();
                return "Se inserto el cliente correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable ConsultarClientePrendasYFotos(string documentoCliente)
        {
            return from C in DBp.Set<Cliente>()
                   join P in DBp.Set<Prenda>()
                   on C.Documento equals P.Cliente
                   join I in DBp.Set<FotoPrenda>()
                   on P.IdPrenda equals I.idPrenda
                   where C.Documento == documentoCliente
                   select new
                   {
                       ClienteDocumento = C.Documento,
                       ClienteNombre = C.Nombre,
                       ClienteEmail = C.Email,
                       ClienteCelular = C.Celular,

                       idPrenda = P.IdPrenda,
                       tipoPrenda = P.TipoPrenda,
                       DescripcionPrenda = P.Descripcion,
                       ValorPrenda = P.Valor,

                       Imagenes = P.FotoPrendas.Select(f => f.FotoPrenda1).ToList()
                   };
        }

    }
}