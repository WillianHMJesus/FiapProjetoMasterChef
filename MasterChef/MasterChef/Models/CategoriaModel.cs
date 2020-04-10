using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

        [MaxLength(200)]
        [Required]
        public string Descricao { get; set; }
    }
}
