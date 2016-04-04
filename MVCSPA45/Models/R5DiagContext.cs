namespace MVCSPA45.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class R5DiagContext : DbContext
    {
        public R5DiagContext()
            : base("name=R5DiagContext")
        {
        }

        public virtual DbSet<vwEvent> vwEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sLevel)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sOrigin)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sMachine)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sIpAddr)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sUserAcct)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sSource)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sProcess)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sThread)
                .IsUnicode(false);

            modelBuilder.Entity<vwEvent>()
                .Property(e => e.sMessageTag)
                .IsUnicode(false);
        }
    }
}
