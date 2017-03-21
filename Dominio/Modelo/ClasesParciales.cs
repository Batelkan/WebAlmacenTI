using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Modelo
{
    class ClasesParciales
    {
    }

    [MetadataType(typeof(MetadatosSuministro))]
    public partial class Articulos
    { }

    [MetadataType(typeof(MetadatosComputadoras))]
    public partial class Computadoras
    {

    }
}
