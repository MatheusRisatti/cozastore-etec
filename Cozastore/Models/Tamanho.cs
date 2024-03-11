using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cozastore.Models;

[Table ("Tamanho")]
    public class Tamanho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "porfavor, informe e goze a Sigla")]
        [StringLength(5, ErrorMessage = "A Sigla deve possuir no máximo 5 caracteres")]
        public string Sigla { get; set; }
    
        [Required(ErrorMessage = "Digite o nome porfa")]
        [StringLength(30, ErrorMessage = "o Nome deve possuir no máximo 30 caracteres")]
        public string Nome { get; set; }

        public ICollection<Estoque> Estoque { get; set; }
    }
