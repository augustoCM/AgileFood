using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileFood.Models
{
    [Table("Pessoas")]
    public class Pessoas
    {
        [Key]
        public int PessoasId { get; set; }
        public bool Ativo { get; set; }

        //inserido manualmente

        [Required(ErrorMessage = "O Nome é obrigatório.")]

        //termina aqui


        public string Nomes { get; set; }
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="O Telefone é obrigatório.")]        
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        public string Endereco { get; set; }
        public int PessoaTiposId { get; set; }
        public virtual PessoaTipos PessoaTipo { get; set; }




        




    }
}