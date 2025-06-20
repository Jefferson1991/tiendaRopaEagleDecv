﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tiendaRopaEagleDecv.Data;

public partial class railwayContext : DbContext
{
    public railwayContext(DbContextOptions<railwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorias> Categorias { get; set; }

    public virtual DbSet<Inventario> Inventario { get; set; }

    public virtual DbSet<ProductoColores> ProductoColores { get; set; }

    public virtual DbSet<ProductoTallas> ProductoTallas { get; set; }

    public virtual DbSet<Productos> Productos { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.HasIndex(e => e.IdCategoriaPadre, "IdCategoriaPadre");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdCategoriaPadreNavigation).WithMany(p => p.InverseIdCategoriaPadreNavigation)
                .HasForeignKey(d => d.IdCategoriaPadre)
                .HasConstraintName("Categorias_ibfk_1");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario).HasName("PRIMARY");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.Stock).HasDefaultValueSql("'0'");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Inventario)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("Inventario_ibfk_1");
        });

        modelBuilder.Entity<ProductoColores>(entity =>
        {
            entity.HasKey(e => e.IdProductoColor).HasName("PRIMARY");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.Color).HasMaxLength(50);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoColores)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("ProductoColores_ibfk_1");
        });

        modelBuilder.Entity<ProductoTallas>(entity =>
        {
            entity.HasKey(e => e.IdProductoTalla).HasName("PRIMARY");

            entity.HasIndex(e => e.IdProducto, "IdProducto");

            entity.Property(e => e.Talla).HasMaxLength(20);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoTallas)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("ProductoTallas_ibfk_1");
        });

        modelBuilder.Entity<Productos>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.HasIndex(e => e.Codigo, "Codigo").IsUnique();

            entity.HasIndex(e => e.IdCategoria, "IdCategoria");

            entity.Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.Marca).HasMaxLength(100);
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("Productos_ibfk_1");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.HasIndex(e => e.Nombre, "Nombre").IsUnique();

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.HasIndex(e => e.IdRol, "IdRol");

            entity.HasIndex(e => e.NombreUsuario, "NombreUsuario").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValueSql("'1'");
            entity.Property(e => e.ContrasenaHash)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Usuarios_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}