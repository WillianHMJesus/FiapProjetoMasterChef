using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterChef.Models
{
    public class ReceitaModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(1000)]
        [Required]
        public string TempoPreparo { get; set; }

        [Required]
        public int RendimentoPorcoes { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Ingredientes { get; set; }

        [MaxLength(1000)]
        [Required]
        public string ModoPreparo { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Cobertura { get; set; }

        [MaxLength(200)]
        [Required]
        public string InfoAdicional { get; set; }

        [MaxLength(200)]
        [Required]
        public string CaminhoImagem { get; set; }

        public int QtdeComentarios { get; set; }

        public virtual IEnumerable<ComentarioModel> Comentarios { get; set; }
        public virtual IEnumerable<CategoriaModel> ReceitasCategorias { get; set; }
    }
}
