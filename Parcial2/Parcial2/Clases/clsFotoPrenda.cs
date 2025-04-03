﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Parcial2.Models;

namespace Parcial2.Clases
{
        public class clsFotoPrenda
        {

        private DBExamenEntities DBp = new DBExamenEntities();
        public FotoPrenda ftprenda { get; set; }

        public List<FotoPrenda> ConsultarTodos()
        {
            return DBp.FotoPrendas
                   .OrderBy(ftp => ftp.idFoto)
                   .ToList();
        }

        public List<FotoPrenda> ConsultarFotosxPrenda(int IdFoto)
        {
            return DBp.FotoPrendas
                .Where(ftp => ftp.idFoto == IdFoto)
                .ToList();
        }

        public string InsertarFotoPrenda()
        {

            try
            {
                DBp.FotoPrendas.Add(ftprenda);
                DBp.SaveChanges();
                return "Se ingresa la imagen correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                FotoPrenda foto = Consultar(ftprenda.idPrenda);
                if (foto == null)
                {
                    return "La foto con el Id ingresado no existe, por lo tanto no se puede actualizar";
                }
                DBp.FotoPrendas.AddOrUpdate(foto); 
                DBp.SaveChanges();
                return "Se elimino la foto correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar la foto: " + ex.Message;
            }
        }

        public string Eliminar(int IdFoto)
        {
            try
            {
                FotoPrenda foto = Consultar(IdFoto);
                if (foto == null)
                {
                    return "La foto con el Id ingresado no existe, por lo tanto no se puede actualizar";
                }
                DBp.FotoPrendas.Remove(foto);
                DBp.SaveChanges();
                return "Se elimino la foto correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar la foto: " + ex.Message;
            }
        }

        public FotoPrenda Consultar(int IdFoto)
        {
            return DBp.FotoPrendas.FirstOrDefault(e => e.idFoto == IdFoto);
        }

        public string GrabarImagenPrenda(int idPrenda, List<string> Imagenes)
        {
            try
            {
                foreach (string imagen in Imagenes)
                {
                    FotoPrenda imagenPrenda = new FotoPrenda();
                    imagenPrenda.idPrenda = idPrenda;
                    imagenPrenda.FotoPrenda1 = imagen;
                    DBp.FotoPrendas.Add(imagenPrenda);
                    DBp.SaveChanges();
                }
                return "Se grabó la información en la base de datos";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
    