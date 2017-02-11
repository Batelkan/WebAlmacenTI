using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Models;

namespace Dominio.Abstracto
{
    class ISuministroRespositorio
    {
        IEnumerable<Articulos> Suministros { get; set; }
    }
}
