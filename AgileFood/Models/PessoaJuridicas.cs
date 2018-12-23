using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileFood.Models
{
    [Table("PessoaJuridicas")]
    public class PessoaJuridicas : Pessoas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PessoaJuridicasId { get; set; }

        //[Required(ErrorMessage = "O Nome Fantasia é obrigatório.")]
        //[MaxLength(50)]
        //public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "A Razão Social é obrigatório.")]
        [MaxLength(50)]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [MaxLength(20)]
        public string InscricaoEstadual { get; set; }


    }
}