using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BDCrudTestMVC.Models;

public partial class BdcrudTestMvcContext : DbContext
{
    public BdcrudTestMvcContext()
    {
    }

    public BdcrudTestMvcContext(DbContextOptions<BdcrudTestMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoCategorium> CoCategoria { get; set; }

    public virtual DbSet<CoProducto> CoProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseSqlServer("server=localhost; database=BDCrudTestMVC; integrated security=true; Encrypt=False;");

        }
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {  }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("server=localhost; database=BDCrudTestMVC; integrated security=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoCategorium>(entity =>
        {
            entity.HasKey(e => e.NIdCategori).HasName("PK__coCatego__59268228CF2BB746");

            entity.ToTable("coCategoria");

            entity.Property(e => e.NIdCategori).HasColumnName("nIdCategori");
            entity.Property(e => e.CEsActiva).HasColumnName("cEsActiva");
            entity.Property(e => e.CNombCateg)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cNombCateg");
        });

        modelBuilder.Entity<CoProducto>(entity =>
        {
            entity.HasKey(e => e.NIdProduct).HasName("PK__coProduc__15A1B6AC79FE9266");

            entity.ToTable("coProducto");

            entity.Property(e => e.NIdProduct).HasColumnName("nIdProduct");
            entity.Property(e => e.CNombProdu)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cNombProdu");
            entity.Property(e => e.NIdCategori).HasColumnName("nIdCategori");
            entity.Property(e => e.NPrecioProd)
                .HasColumnType("money")
                .HasColumnName("nPrecioProd");

            entity.HasOne(d => d.NIdCategoriNavigation).WithMany(p => p.CoProductos)
                .HasForeignKey(d => d.NIdCategori)
                .HasConstraintName("FK__coProduct__nIdCa__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
