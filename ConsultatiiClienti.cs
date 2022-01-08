using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Consultatii
{
    public partial class ConsultatiiClienti : DbContext
    {
        public ConsultatiiClienti()
            : base("name=ConsultatiiClienti")
        {
        }

        public virtual DbSet<Cadru> Cadrus { get; set; }
        public virtual DbSet<Pacient> Pacients { get; set; }
        public virtual DbSet<Programare> Programares { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cadru>()
                .HasMany(e => e.Programares)
                .WithOptional(e => e.Cadru)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Pacient>()
                .HasMany(e => e.Programares)
                .WithOptional(e => e.Pacient)
                .WillCascadeOnDelete();
        }
    }
}
