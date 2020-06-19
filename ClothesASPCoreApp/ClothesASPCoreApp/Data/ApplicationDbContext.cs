using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClothesASPCoreApp.Models;

namespace ClothesASPCoreApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<SpecialTags> SpecialTags { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
