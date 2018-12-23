using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileFood.Models
{
    [Table("PessoaFisicas")]
    public class PessoaFisicas : Pessoas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PessoaFisicasId { get; set; }

        //[Required(ErrorMessage = "O Nome é obrigatório.")]
        //[MaxLength(50)]
        //public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [MaxLength(20)]
        public string RG { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]//Formata a visualização na view Index (LISTA DAS INFORMAÇÕES)
        [DataType(DataType.Date, ErrorMessage ="Data em formato invalido.")]//Seta a propriedade do campo na hora de inserir a informação
        public DateTime DataNascimento { get; set; }


    }
}