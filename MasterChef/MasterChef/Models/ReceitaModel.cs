using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MasterChef.Models
{
    public class ReceitaModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public string Nome { get; set; }

        [MaxLength(1000)]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        [DisplayName("Tempo de Preparo")]
        public string TempoPreparo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        [DisplayName("Rendimento por Porção")]
        public int RendimentoPorcoes { get; set; }

        [MaxLength(1000)]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public string Ingredientes { get; set; }

        [MaxLength(1000)]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        [DisplayName("Modo de Preparo")]
        public string ModoPreparo { get; set; }

        [MaxLength(1000)]
        [Required(ErrorMessage = "O campo {0} é obrigátorio")]
        public string Cobertura { get; set; }

        [MaxLength(200)]
        [DisplayName("Informações Adicionais")]
        public string InformacaoAdicional { get; set; }

        [MaxLength(200)]
        public string DiretorioImagem { get; set; }

        public int QtdeComentarios { get; set; }

        public virtual IEnumerable<ComentarioModel> Comentarios { get; set; }
        public virtual IEnumerable<CategoriaModel> ReceitasCategorias { get; set; }
    }
}
