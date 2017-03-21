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

       public void SalvarComputadora(Computadoras comp)
        {

        }

       public void BorrarComputadora(Computadoras comp)
        {

        }

    }
}
