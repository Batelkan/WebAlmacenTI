﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dominio.Modelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlmacenEntidades : DbContext
    {
        public AlmacenEntidades()
            : base("name=AlmacenEntidades")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Arca> Arca { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Computadoras> Computadoras { get; set; }
        public DbSet<Datos> Datos { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Unidades> Unidades { get; set; }
        public DbSet<UnidadNegocio> UnidadNegocio { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<WebAdminUser> WebAdminUser { get; set; }
    }
}