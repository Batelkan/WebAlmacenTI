using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Modelo
{
   public class MetadatosSuministro
    {
        [Required(ErrorMessage = "Escribe el nombre del fabricate")]
        public string Fabricante;

        [Required(ErrorMessage = "Escribe el no. serie")]
        public string Serie;

        [Required(ErrorMessage = "Escribe el no modelo")]
        public string Modelo;

        [Required(ErrorMessage = "Escribe una descripcion del producto")]
        public string Descripcion;

        public string Observaciones;

        [Required(ErrorMessage = "selecciona el estatus")]
        public string Estatus;

        [Required(ErrorMessage = "selecciona la categoria")]
        public string Tipo;

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Selecciona la fecha")]
        public DateTime FechaAlta;

        [Required(ErrorMessage = "Escribe la factura")]
        public string Factura;

        [Required(ErrorMessage = "Escribe la cantidad total adquirida")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tiene que ser un valor positivo")]
        public int Cantidad;

        [Required(ErrorMessage = "Escribe la cantidad total disponible")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tiene que ser un valor positivo")]
        public int CantidadDisponible;

        [Required(ErrorMessage = "Escribe el nombre del producto")]
        public string Nombre;

        [Required(ErrorMessage = "Escribe  su precio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tiene que ser un valor positivo")]
        public decimal precio;

        [Required(ErrorMessage = "Escribe el nombre del proveedor")]
        public string Proveedor;

        [Required(ErrorMessage = "Escribe el precio unitario del producto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Tiene que ser un valor positivo")]
        public decimal precioUnitario;
    }

    public class MetadatosComputadoras
    {
        [Required(ErrorMessage = "Selecciona el Tipo de Computadora")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Escribe el nombre del fabricate")]
        public string Fabricante { get; set; }
        [Required(ErrorMessage = "Escribe numero de serie")]
        public string serie { get; set; }
        [Required(ErrorMessage = "Escribe el modelo del equipo")]
        public string modelo { get; set; }
        [Required(ErrorMessage = "Escribe el folio de factura del equipo")]
        public string factura { get; set; }
        [Required(ErrorMessage = "Escribe la ip del equipo")]
        public string IP { get; set; }
        [Required(ErrorMessage = "Escribe la mac del equipo")]
        public string MAC { get; set; }
        [Required(ErrorMessage = "Debes seleccionar una fecha de ingreso")]
        public System.DateTime FechaAlta { get; set; }
        [Required(ErrorMessage = "Seleccion el status del equipo")]
        public string Estatus { get; set; }
        [Required(ErrorMessage = "Escribe la descripcion del equipo")]
        public string Descripcion { get; set; }

        public string Observaciones { get; set; }
        [Required(ErrorMessage = "Escribe el nombre del proveedor")]
        public string Proveedor { get; set; }
        [Required(ErrorMessage = "Escribe el tipo de procesador")]
        public string Procesador { get; set; }
        [Required(ErrorMessage = "Escribe la cantidad de ram")]
        public string Ram { get; set; }
        [Required(ErrorMessage = "Escribe la cantidad de alamcenamiento")]
        public string HD { get; set; }
        [Required(ErrorMessage = "Escribe el tipo de video")]
        public string Video { get; set; }
        [Required(ErrorMessage = "Escribe los tipos de IO")]
        public string E_S { get; set; }
        [Required(ErrorMessage = "Escribe el precio de compra sin iva")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Escribe el tipo de tarjeta madre")]
        public string Madre { get; set; }
    }

}
