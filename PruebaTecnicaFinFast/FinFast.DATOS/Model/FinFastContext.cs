using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinFast.DATOS.Model
{
    public partial class FinFastContext : DbContext
    {
        private readonly string _connectionString;
        public FinFastContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public FinFastContext(DbContextOptions<FinFastContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Comuna> Comunas { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => new { e.RegionCodigo, e.Codigo });

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.RegionCodigoNavigation)
                    .WithMany(p => p.Ciudads)
                    .HasForeignKey(d => d.RegionCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Region");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.HasKey(e => new { e.RegionCodigo, e.CiudadCodigo, e.Codigo });

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Comunas)
                    .HasForeignKey(d => new { d.RegionCodigo, d.CiudadCodigo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comuna_Ciudad");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApellidoMaterno).IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](95),(((rtrim(ltrim([ApellidoPaterno]))+' ')+isnull(rtrim(ltrim([ApellidoMaterno])),''))+', ')+rtrim(ltrim([Nombres])),(0)))", false);

                entity.Property(e => e.Nombres).IsUnicode(false);

                entity.Property(e => e.Run)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar],([dbo].[FormatInt]([RunCuerpo])+'-')+[RunDigito],(0)))", false);

                entity.Property(e => e.RunDigito)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SexoCodigoNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.SexoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Sexo");

                entity.HasOne(d => d.Comuna)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => new { d.RegionCodigo, d.CiudadCodigo, d.ComunaCodigo })
                    .HasConstraintName("FK_Persona_Comuna");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.NombreOficial).IsUnicode(false);
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Letra)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
