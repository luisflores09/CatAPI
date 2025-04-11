using System;
using CatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatAPI.Data
{
    public class CatDbContext : DbContext
    {
        public CatDbContext(DbContextOptions<CatDbContext> options) : base(options) { }
        public DbSet<Cat> Cats { get; set;}
    }
}