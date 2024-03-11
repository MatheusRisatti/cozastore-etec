using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace Cozastore.Models;

[Table("Usuario")]
public class Usuario
{
    [Key]
    public string UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public IdentityUser ContaUsuario { get; set; }
    [Required(ErrorMessage = "Digite o nome porfa")]
    [StringLength(30, ErrorMessage = "o Nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de nascimento")]
    [Required(ErrorMessage = "Por favor informe  a data de nascimento")]

    public DateTime DataNascimento { get; set; }
    [StringLength(300)]
    public string Foto { get; set; }
}