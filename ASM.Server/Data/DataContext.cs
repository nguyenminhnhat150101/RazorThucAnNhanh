/*
using System;
using ASM.Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ASM.Server.Models
{
    public partial class DataContext : DbContext
    {
        //public EmployeeContext()
        //{
        //}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<MonAn> MonAns { get; set; }

        public DbSet<Nguoidung> Nguoidungs { get; set; }

        public DbSet<Donhang> Donhangs { get; set; }

        public DbSet<Khachhang> Khachhangs { get; set; }

        public DbSet<DonhangChitiet> DonhangChitiets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
*/