using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace prueba.Models
{
    public partial class pruebaContext : DbContext
    {
        public pruebaContext()
        {
        }

        public pruebaContext(DbContextOptions<pruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PBolsa> PBolsas { get; set; }
        public virtual DbSet<PCaja> PCajas { get; set; }
        public virtual DbSet<PCarpetum> PCarpeta { get; set; }
        public virtual DbSet<PDocumento> PDocumentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=prueba", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<PBolsa>(entity =>
            {
                entity.HasKey(e => e.IdPBolsa)
                    .HasName("PRIMARY");

                entity.ToTable("p_bolsa");

                entity.HasIndex(e => e.PCajaIsPCaja, "fk_P_Bolsa_P_Caja1_idx");

                entity.Property(e => e.IdPBolsa).HasColumnName("id_P_Bolsa");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.PCajaIsPCaja).HasColumnName("P_Caja_is_P_Caja");
            });

            modelBuilder.Entity<PCaja>(entity =>
            {
                entity.HasKey(e => e.IdPCaja)
                    .HasName("PRIMARY");

                entity.ToTable("p_caja");

                entity.Property(e => e.IdPCaja).HasColumnName("id_P_Caja");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PCarpetum>(entity =>
            {
                entity.HasKey(e => e.IdPCarpeta)
                    .HasName("PRIMARY");

                entity.ToTable("p_carpeta");

                entity.HasIndex(e => e.PBolsaIdPBolsa, "fk_P_Carpeta_P_Bolsa1_idx");

                entity.Property(e => e.IdPCarpeta).HasColumnName("id_P_Carpeta");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.PBolsaIdPBolsa).HasColumnName("P_Bolsa_id_P_Bolsa");
            });

            modelBuilder.Entity<PDocumento>(entity =>
            {
                entity.HasKey(e => e.IdPDocumento)
                    .HasName("PRIMARY");

                entity.ToTable("p_documento");

                entity.HasIndex(e => e.PCarpetaIdPCarpeta, "fk_P_Documento_P_Carpeta_idx");

                entity.Property(e => e.IdPDocumento).HasColumnName("id_P_Documento");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.PCarpetaIdPCarpeta).HasColumnName("P_Carpeta_id_P_Carpeta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
