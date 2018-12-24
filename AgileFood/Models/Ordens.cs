using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileFood.Models
{
    public class Ordens
    {
        [Key]
        public int OrdensId { get; set; }

        [Required(ErrorMessage = "O Cliente é obrigatório")]
        [Range(1, double.MaxValue, ErrorMessage = "You must select a {0}")]
        public int FornecedoresId { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "A Data é obrigatório.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        
        [Display(Name = "Anotação")]
        [DataType(DataType.MultilineText)]
        public string Anotacao { get; set; }

        public virtual Fornecedores Fornecedor { get; set; }

        public virtual Funcionarios Funcionario { get; set; }

        //detalheordens
        // public virtual ICollection<DetalheOrdens> DetalheOrden { get; set; }


    }
}