using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Abstracto;
using Dominio.Modelo;

namespace Dominio.Concreto
{
   public class SuministroRepositorio:ISuministroRespositorio
    {
       AlmacenEntidades contexto = new AlmacenEntidades();
       public IEnumerable<Articulos> Suministros
        {
            get { return contexto.Articulos; }
            set { }
        }

        public IEnumerable<Tipo> categoria
        {
            get { return contexto.Tipo; }
            set { }
        }

        public void SalvarSuminnistro(Articulos art)
        {
            if(art.ID == 0)
            {
                contexto.Articulos.Add(art);
            }

            else
            {
                Articulos EFentrada = contexto.Articulos.Find(art.ID);
                if(EFentrada != null)
                {
                    EFentrada.Nombre = art.Nombre;
                    EFentrada.Modelo = art.Modelo;
                    EFentrada.Observaciones = art.Observaciones;
                    EFentrada.precio = art.precio;
                    EFentrada.precioUnitario = art.precioUnitario;
                    EFentrada.Proveedor = art.Proveedor;
                    EFentrada.Serie = art.Serie;
                    EFentrada.Tipo = art.Tipo;
                    EFentrada.Cantidad = art.Cantidad;
                    EFentrada.CantidadDisponible = art.CantidadDisponible;
                    EFentrada.Descripcion = art.Descripcion;
                    EFentrada.Estatus = art.Estatus;
                    EFentrada.Fabricante = art.Fabricante;
                    EFentrada.Factura = art.Factura;
                    EFentrada.FechaAlta = art.FechaAlta;
                   
                }
            }

            contexto.SaveChanges();
        }

       public void BorrarSuminnistro(Articulos art)
        {
            if (art.ID != 0)
            {
               var sumi =  contexto.Articulos.Where(s=> s.ID == art.ID).FirstOrDefault();
                contexto.Articulos.Remove(sumi);
                contexto.SaveChanges();
            }

        }
    }
}
