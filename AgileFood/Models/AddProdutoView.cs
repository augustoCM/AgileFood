using System.ComponentModel.DataAnnotations;

namespace AgileFood.Models
{
    public class AddProdutoView
    {
        [Required(ErrorMessage ="O Produto é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage ="")]
        [Display(Name ="Produto")]
        public int ProdutosId { get; set; }

        [Required(ErrorMessage = "A Quantidade é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "Valores maiores que 0")]
        public double Quantidade { get; set; }
    }
}