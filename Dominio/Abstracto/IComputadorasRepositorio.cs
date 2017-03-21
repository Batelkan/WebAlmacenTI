using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelo;

namespace Dominio.Abstracto
{
    public interface IComputadorasRepositorio
    {
        IEnumerable<Computadoras> Computo { get; set; }
        void SalvarComputadora(Computadoras comp);
        void BorrarComputadora(Computadoras comp);
    }
}
