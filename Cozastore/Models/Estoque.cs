using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozastore.Models;

[Table("Estoque")]
public class Estoque
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
      [Display(Name = "Pruduto")]
    [Required(ErrorMessage = "porfavor, informe o produto")]
    public int ProdutoId { get; set; }
    [ForeignKey("ProdutoId")]

    public Produto Produto {get; set;}

        [Display(Name = "Tamanho")]
    [Required(ErrorMessage = "porfavor, informe o tamanho")]
    public int TamanhoId { get; set; }
    [ForeignKey("TamanhoId")]

    public Tamanho Tamanho { get; set; }

    [Display(Name = "Cor")]
    [Required(ErrorMessage = "porfavor, informe a cor")]
    public int CorId { get; set; }
    [ForeignKey("CorId")]

    public Cor Cor { get; set; }

     [Display (Name = "Preço")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Preco { get; set; }
        
        [Display (Name = "Preço com Desconto")]
        [Column(TypeName = "decimal(8,2)")]
        
        public decimal? PrecoDesconto { get; set; }

        [Display (Name = "Qtde em Estoque")]
        [Required(ErrorMessage = "porfavor, informe a Qtde em Estoque")]
        public int QtdeEstoque { get; set; }
}