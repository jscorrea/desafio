using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClientesTG.Models
{
    public partial class JC_TH_TestContext : DbContext
    {
           public JC_TH_TestContext(DbContextOptions<JC_TH_TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Logradouros> Logradouros { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__Clientes__71ABD087AAEF1758");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logotipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logradouros>(entity =>
            {
                entity.HasKey(e => e.LogradouroId)
                    .HasName("PK__Logradou__077E4242C2B8D604");

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne<Clientes>(d => d.Cliente)
                    .WithMany(p => p.Logradouros)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Logradour__Clien__1920BF5C");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Usuarios__1788CC4CA782B1AC");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
