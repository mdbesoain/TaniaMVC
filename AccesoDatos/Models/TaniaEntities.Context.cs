//------------------------------------------------------------------------------
// <auto-generated>
//    Este c�digo se gener� a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaci�n.
//    Los cambios manuales en este archivo se sobrescribir�n si se regenera el c�digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class TaniaEntitiesContainer : DbContext
    {
        public TaniaEntitiesContainer()
            : base("name=TaniaEntitiesContainer")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Auspiciador> Auspiciadores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Logro> Logros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
    }
}