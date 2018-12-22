using System.ComponentModel.DataAnnotations;

namespace AgileFood.Models
{
    public class Fornecedores
    {
        [Key]
        public int FornecedoresId { get; set; }
        public int PessoasId { get; set; }
        public virtual Pessoas Pessoa { get; set; }
    }
}