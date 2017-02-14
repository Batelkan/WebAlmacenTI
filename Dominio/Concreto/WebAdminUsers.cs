using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Abstracto;
using Dominio.Modelo;

namespace Dominio.Concreto
{
   public class WebAdminUsers:IWebAdminUsers
    {
        AlmacenEntidades contexto = new AlmacenEntidades();
        public IEnumerable<WebAdminUser> WebAdmin
        {
            get { return contexto.WebAdminUser; }
            set { }
        }
    }
}
