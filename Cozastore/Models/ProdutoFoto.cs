using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozastore.Models;

[Table("ProdutoFoto")]
public class ProdutoFoto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Pruduto")]
    [Required(ErrorMessage = "porfavor, informe o produto")]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutoId")]

    public Produto Produto { get; set; }
    
    [Required(ErrorMessage = "porfavor, porfavor faça upload da Foto")]
    [StringLength(300)]
    public string ArquivoFoto { get; set; }

    [Display(Name = "Foto Destaque")]

    public bool Destaque { get; set; }
}