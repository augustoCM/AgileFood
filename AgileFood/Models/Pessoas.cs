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

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nomes { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage ="O Telefone é obrigatório.")]        
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        public string Endereco { get; set; }
        public int PessoaTiposId { get; set; }

        public virtual PessoaTipos PessoaTipo { get; set; }
        public virtual ICollection<Fornecedores> Fornecedor { get; set; }
        public virtual ICollection<Funcionarios> Funcionario { get; set; }









    }
}