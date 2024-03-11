using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
   
namespace Cozastore.Models;

    [Table("Produto")]
    public class Produto
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Digite o nome porfa")]
        [StringLength(100, ErrorMessage = "o Nome deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição Resumida")]
        [StringLength(1000, ErrorMessage = "A Descrição deve conter no máximo 1000 caracteres")]

        public string DescricaoResumida { get; set; }
        
        [Display(Name = "Descrição Completa")]
        [StringLength(8000, ErrorMessage = "A Descrição deve conter no máximo 8000 caracteres")]

        public string DescricaoCompleta { get; set; }

        [Display (Name = "SKU")]
        [StringLength (10, ErrorMessage = "O SKU deve conter no máximo 10 caracteres")]

        public string SKU { get; set; }

        [Display (Name = "Preço")]
        [Column(TypeName = "decimal(8,2)")]
        [Required(ErrorMessage = "Por favor, informe o preço de Venda")]
        public decimal Preco { get; set; }
        
        [Display (Name = "Preço com Desconto")]
        [Column(TypeName = "decimal(8,2)")]
        [Required(ErrorMessage = "Por favor, informe o preço com Desconto de Venda")]
        public decimal PrecoDesconto { get; set; }

        [Display (Name = "Produto em Destaque ?")]
        public bool Destaque { get; set; } = false;

        [Column (TypeName = "decimal(8,3)")]

        public double Peso { get; set; } = 0;

        [StringLength(50, ErrorMessage = "O Material deve possuir no máximo 50 caracteres")]

        public string Material { get; set; }

        [Display (Name = "Dimensões")]
        [StringLength(20, ErrorMessage = "As Dimensões deve possuir no máximo 20 caracteres")]

        public string Dimensao { get; set; }
        
        [Display (Name = "Categoria")]
        [Required(ErrorMessage = "Por favor, informe a categoria")]

        public int CategoriaId { get; set; }

        [ForeignKey ("CategoriaId")]
        public Categoria Categoria { get; set; }

        public ICollection<Estoque> Estoque { get; set; }

    }
