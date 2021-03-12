using System.ComponentModel.DataAnnotations;

namespace MasterChef.Models
{
    public class ComentarioModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(200)]
        [Required]
        public string ComentarioTexto { get; set; }

        public int ReceitaId { get; set; }
    }
}
