using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Abstracto;
using WebUI.Models;

namespace Dominio.Concreto
{
   public class SuministroRepositorio:ISuministroRespositorio
    {
        InformaticaEntities contexto = new InformaticaEntities();
       public IEnumerable<Articulos> Suministros
        {
            get { return contexto.Articulos; }
            set { }
        }
    }
}
