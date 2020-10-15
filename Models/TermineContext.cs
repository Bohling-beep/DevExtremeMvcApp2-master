namespace DevExtremeMvcApp2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TermineContext : DbContext
    {
        public TermineContext()
            : base("name=TermineContext")
        {
        }

        public virtual DbSet<Termine> Termine { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
              
            modelBuilder.Entity<Termine>()
                .Property(e => e.Titel)
                .IsFixedLength();

            modelBuilder.Entity<Termine>()
                .Property(e => e.Start)
                .IsFixedLength();

            modelBuilder.Entity<Termine>()
                .Property(e => e.Ende)
                .IsFixedLength();

            modelBuilder.Entity<Termine>()
                .Property(e => e.Farbe)
                .IsFixedLength();
        }
    }
}
