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
    }
}
