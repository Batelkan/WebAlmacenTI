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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy 00:00:00}")]
        [Required(ErrorMessage = "Selecciona la fecha")]
        public System.DateTime FechaAlta;

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
}
