﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PJ_WEBAPP001.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD_ActivoFijosEntities : DbContext
    {
        public BD_ActivoFijosEntities()
            : base("name=BD_ActivoFijosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTIVO> ACTIVO { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<DETALLESOLICITUD> DETALLESOLICITUD { get; set; }
        public virtual DbSet<DISTRITO> DISTRITO { get; set; }
        public virtual DbSet<MARCAS> MARCAS { get; set; }
        public virtual DbSet<SOLICITUD> SOLICITUD { get; set; }
        public virtual DbSet<TRABAJADOR> TRABAJADOR { get; set; }
    }
}