using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public DateTime? CreatedOn { get; set; }

        public int ReceitaId { get; set; }
        public virtual ReceitaModel Receita { get; set; }
    }
}
