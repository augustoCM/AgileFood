
using System.ComponentModel.DataAnnotations;

namespace AgileFood.Models
{
    public class Produtos
    {
        [Key]
        public int ProdutosId { get; set; }

        [Display(Name ="Nome")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo Valor é requerido!!")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal preco { get; set; }
        
        //[Display(Name = "Imagem")]
        //[DataType(DataType.ImageUrl)]
        //public string Image { get; set; }

        //[NotMapped]
        //[Display(Name = "Imagem")]
        //public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Anotação")]
        [DataType(DataType.MultilineText)]
        public string Anotacao { get; set; }

      







    }
}