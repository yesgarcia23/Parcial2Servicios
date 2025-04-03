using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Parcial2.Models;

namespace Parcial2.Clases
{
    public class clsPrenda
    {

        private DBExamenEntities DBp = new DBExamenEntities();
        public Prenda prenda { get; set; }

        public List<Prenda> ConsultarTodos()
        {
            return DBp.Prendas
                   .OrderBy(p =>p.IdPrenda )
                   .ToList();
        }

        public List<Prenda> ConsultarxId(int IdPrenda)
        {
            return DBp.Prendas
                .Where(p => p.IdPrenda == IdPrenda)
                .ToList();
        }

        public string InsertarPrenda()
        {

            try
            {
                if (string.IsNullOrEmpty(prenda.Cliente))
                {
                    return "El cliente no está especificado.";
                }
                DBp.Prendas.Add(prenda);
                DBp.SaveChanges();
                return "Se registra la información de la prenda correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GrabarImagenPrenda(int idPrenda, List<string> Imagenes)
        {
            try
            {
                foreach (string imagen in Imagenes)
                {
                    FotoPrenda fotoPrenda = new FotoPrenda();
                    fotoPrenda.idPrenda = idPrenda;
                    fotoPrenda.FotoPrenda1 = imagen;
                    DBp.FotoPrendas.Add(fotoPrenda);
                    DBp.SaveChanges();
                }
                return "Se grabó la información en la base de datos";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public IQueryable ListarPrendasEImagenesXCliente(string documentoCliente)
        {
            return from C in DBp.Clientes
                   join P in DBp.Prendas on C.Documento equals P.Cliente
                   join I in DBp.FotoPrendas on P.IdPrenda equals I.idPrenda
                   where C.Documento == documentoCliente
                   orderby P.TipoPrenda, I.FotoPrenda1
                   select new
                   {
                       idCliente = C.Documento,
                       NombreCliente = C.Nombre,
                       idPrenda = P.IdPrenda,
                       TipoPrenda = P.TipoPrenda,
                       DescripcionPrenda = P.Descripcion,
                       ValorPrenda = P.Valor,
                       Imagen = I.FotoPrenda1
                   };
        }



    }
}
