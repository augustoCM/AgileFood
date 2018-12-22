using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgileFood.Models
{

    public class PessoaTipos
    {
        [Key]
        public int PessoaTiposId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Pessoas> Pessoa { get; set; }
    }
}