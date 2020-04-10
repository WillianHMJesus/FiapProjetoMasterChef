using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MasterChef.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string PrimeiroNome { get; set; }

        [MaxLength(100)]
        [Required]
        public string SobreNome { get; set; }

        [MaxLength(50)]
        [Required]
        public string Username { get; set; }

        [MaxLength(50)]
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
