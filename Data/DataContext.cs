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

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<User> Users { get; set; }

  }
}