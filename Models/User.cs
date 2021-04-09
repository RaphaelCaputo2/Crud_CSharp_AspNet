using System.ComponentModel.DataAnnotations;



namespace CSharp.MVC.Models
{
  public class User
  {
    [Key]

    public int Id { get; set; }
    [Required(ErrorMessage = "Esse campo é obrigatório")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]

    public string Usename { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]


    public string Password { get; set; }

    public string Role { get; set; }




  }
}