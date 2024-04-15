using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozastore.Models;

[Table("Cor")]
public class Cor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Digite o nome porfa")]
    [StringLength(30, ErrorMessage = "o Nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [Display(Name = "Código Hexa", Prompt = "Ex. #000000")]
    [Required(ErrorMessage = "Informe por favor, o Código Hexa")]
    [StringLength(7, ErrorMessage = "O código Hexa deve possuir no maximo 7 caracteres")]
    public string CodigoHexa { get; set; }

    public ICollection<Estoque> Estoque { get; set; }
}