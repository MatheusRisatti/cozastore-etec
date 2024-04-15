using System.ComponentModel.DataAnnotations;

namespace CozaStore.ViewModels;

public class LoginVM
{

    [Display(Name = "Email ou Nome de Usuario")]
    [Required(ErrorMessage = "Por favor, informe seu email ou Nome de Usuario")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Senha de Acesso")]
    [Required(ErrorMessage = "Por favor, informe sua senha")]
    public string Senha { get; set; }

    [Display(Name = "Manter Conectado?")]

    public bool Lembrar { get; set; } = false;

    public string UrlRetorno { get; set; }
}