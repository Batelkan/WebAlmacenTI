//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articulos
    {
        public int ID { get; set; }
        public string Fabricante { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public string Estatus { get; set; }
        public string Tipo { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public string Factura { get; set; }
        public int Cantidad { get; set; }
        public int CantidadDisponible { get; set; }
        public string Nombre { get; set; }
        public decimal precio { get; set; }
        public string Proveedor { get; set; }
        public decimal precioUnitario { get; set; }
    }
}
