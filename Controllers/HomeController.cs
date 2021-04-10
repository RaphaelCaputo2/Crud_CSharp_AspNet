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
      var employee = new User { Usename = "robin", Password = "robin", Role = "funcionario" };
      var manager = new User { Usename = "batman", Password = "batman", Role = "gerente" };
      var category = new Category { Title = "Informática" };
      var product = new Product { Category = category, Title = "Mouse", Price = 299, Description = "Mouse Gamer" };
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