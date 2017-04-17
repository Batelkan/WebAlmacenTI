using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Abstracto;
using Dominio.Modelo;

namespace Dominio.Concreto
{
   public class ComputadoraRepositorio:IComputadorasRepositorio
    {
        AlmacenEntidades contexto = new AlmacenEntidades();
        public IEnumerable<Computadoras> Computo
        {
            get { return contexto.Computadoras; }
            set { }
        }

       public IEnumerable<Tipo> categoria { get; set; }

        public void SalvarComputadora(Computadoras comp)
        {
            if(comp.ID == 0)
            {
                contexto.Computadoras.Add(comp);
            }

            else
            { 
            Computadoras EFentrada = contexto.Computadoras.Find(comp.ID);
            if(EFentrada != null)
            {
                    EFentrada.Tipo = comp.Tipo;
                    EFentrada.Fabricante = comp.Fabricante;
                    EFentrada.serie = comp.serie;
                    EFentrada.modelo = comp.modelo;
                    EFentrada.factura = comp.factura;
                    EFentrada.IP = comp.IP;
                    EFentrada.MAC = comp.MAC;
                    EFentrada.FechaAlta = comp.FechaAlta;
                    EFentrada.Estatus = comp.Estatus;
                    EFentrada.Descripcion = comp.Descripcion;
                    EFentrada.Observaciones = comp.Observaciones;
                    EFentrada.Procesador = comp.Procesador;
                    EFentrada.Proveedor = comp.Proveedor;
                    EFentrada.Ram = comp.Ram;
                    EFentrada.HD = comp.HD;
                    EFentrada.Video = comp.Video;
                    EFentrada.E_S = comp.E_S;
                    EFentrada.Precio = comp.Precio;
                    EFentrada.Madre = comp.Madre;
                    
            }

            }
            contexto.SaveChanges();

        }

       public void BorrarComputadora(Computadoras comp)
        {
            if(comp.ID != 0)
            {
                var com = contexto.Computadoras.Where(c => c.ID == comp.ID).FirstOrDefault();
                contexto.Computadoras.Remove(com);
                contexto.SaveChanges();
            }
        }

    }
}
