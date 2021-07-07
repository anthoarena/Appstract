using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCore.Model {
    public class AcmeContext :DbContext {
        public AcmeContext() { }
        public AcmeContext(DbContextOptions<AcmeContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=ZEN\\SQLEXPRESS;Initial Catalog=acmedatabase;Integrated Security=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Contestant> Contestants { get; set; }


        public IEnumerable<Contestant> GetAllContestants() => Contestants;
        public IEnumerable<Product> GetAllProducts() => Products;
        //   public Product AddContestant(Member member) {

        //    Member.Add(member);
        //    SaveChanges();
        //    return member;
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(e => e.ProductId);
                entity.Property(e => e.SerialNumber);
                entity.Property(e => e.Name);

            });


            modelBuilder.Entity<Contestant>(entity => {
                entity.HasKey(e => e.ContestantId);
                entity.Property(e => e.Firstname);
                entity.Property(e => e.Lastname);
                entity.Property(e => e.Email);
                entity.Property(e => e.SerialNumber);
            });


        }

    }
}

