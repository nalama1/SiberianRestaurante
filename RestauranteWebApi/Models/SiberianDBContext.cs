using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestauranteWebApi.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;


#nullable disable

namespace RestauranteWebApi.Models
{
    public partial class SiberianDBContext : DbContext
    {
        public SiberianDBContext()
        {
        }
      

        public SiberianDBContext(DbContextOptions<SiberianDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        //    {"exito":0,"mensaje":"No database provider has been configured for this DbContext. A provider can be configured
        //    by overriding the 'DbContext.OnConfiguring' method or by using 'AddDbContext' on the application service provider.
        //    If 'AddDbContext' is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object
        //    in its constructor and passes it to the base constructor for DbContext.","data":null}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
        //    }
        //}


       
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Idciudad);

                entity.ToTable("Ciudad");

                entity.Property(e => e.Idciudad).HasColumnName("IDCiudad");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.NombreCiudad)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.Idrestaurante);

                entity.Property(e => e.Idrestaurante).HasColumnName("IDRestaurante");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Idciudad).HasColumnName("IDCiudad");

                entity.Property(e => e.NombreRestaurante)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdciudadNavigation)
                    .WithMany(p => p.Restaurantes)
                    .HasForeignKey(d => d.Idciudad)
                    .HasConstraintName("FK_Restaurantes_Ciudad");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.ToTable("Usuario");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RestauranteWebApi.Models.outputCiudad> outputCiudad { get; set; }

        public DbSet<RestauranteWebApi.Models.outputRestaurante> outputRestaurante { get; set; }
    }
}
