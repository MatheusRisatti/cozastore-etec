using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozastore.Models;

    [Table ("Categoria")]
    public class Categoria
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Digite o nome porfa")]
    [StringLength(30, ErrorMessage = "o Nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    [Display(Name = "Exibir como filtro")]
    public bool Filtrar { get; set; }

    [Display(Name = "Exibir como banner")]
    public bool Banner { get; set; }

    [Display(Name = "Categoria Pai")]
    public int? CategoriaPaiId { get; set; }

    [ForeignKey("CategoriaPaiId")]
    public Categoria CategoriaPai { get; set; }

    }
