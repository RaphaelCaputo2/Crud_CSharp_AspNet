using System;
using CSharp.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp.MVC.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

  }
}