using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharp.MVC.Data;
using CSharp.MVC.Models;
using System;
using Microsoft.AspNetCore.Authentication;
using System.Linq;
using CSharp.MVC.Services;
using Microsoft.AspNetCore.Authorization;

namespace CSharp.MVC.Controllers
{
  [Route("users")]
  public class UserController : Controller
  {
    [HttpGet]
    [Route("")]
    [Authorize(Roles = "gerente")]

    public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
    {
      var users = await context.Users.AsNoTracking().ToListAsync();
      return users;
    }



    [HttpPost]
    [Route("")]
    [AllowAnonymous]
    public async Task<ActionResult<User>> Post(
        [FromServices] DataContext context,
        [FromBody] User model)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);


      try
      {
        model.Role = "funcionario";
        context.Users.Add(model);
        await context.SaveChangesAsync();
        model.Password = "";
        return model;
      }
      catch (Exception)
      {
        return BadRequest(new { message = "Não foi possível criar o usuário." });

      }

    }
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<dynamic>> Authenticate(
        [FromServices] DataContext context,
        [FromBody] User model)
    {
      var user = await context.Users.AsNoTracking()
.Where(x => x.Usename == model.Usename && x.Password == model.Password)
.FirstOrDefaultAsync();

      if (user == null)
        return NotFound(new { message = "Usuário ou senha inválidos" });

      var token = TokenService.GenerateToken(user);

      user.Password = "";
      return new
      {
        userName = user.Usename,
        Role = user.Role,
        token = token
      };
    }


  }
}