using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CSharp.MVC.Data;
using CSharp.MVC.Models;

namespace CSharp.MVC.Controllers
{
  [Route("inicio")]
  public class HomeController : Controller
  {
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
    {
      var employee = new User { Id = 1, Usename = "robin", Password = "robin", Role = "funcionario" };
      var manager = new User { Id = 2, Usename = "batman", Password = "batman", Role = "gerente" };
      var category = new Category { Id = 1, Title = "Informática" };
      var product = new Product { Id = 1, Category = category, Title = "Mouse", Price = 299, Description = "Mouse Gamer" };
      context.Users.Add(employee);
      context.Users.Add(manager);
      context.Categories.Add(category);
      context.Products.Add(product);
      await context.SaveChangesAsync();

      return Ok(new
      {
        message = "Dados configurados"
      });
    }
  }
}