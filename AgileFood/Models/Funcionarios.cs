using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Funcionarios
    {
        [Key]
        public int FuncionariosId { get; set; }
        public int PessoasId { get; set; }
        public virtual Pessoas Pessoa { get; set; }
    }
}