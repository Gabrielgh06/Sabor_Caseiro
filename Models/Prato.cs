using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaborCaseiro.Models
{
    public class Prato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }  

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A imagem é obrigatório")]
        public string ImageUrl { get; set; }
        
        // Construtor garantindo que as propriedades não sejam nulas
        public Prato()
        {
            Name = string.Empty;  // Inicializa com uma string vazia
            Description = string.Empty;
            ImageUrl = string.Empty;
        }
    }
}
