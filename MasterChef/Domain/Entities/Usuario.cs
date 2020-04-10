using System;

namespace Domain.Entities
{
    public class Usuario:BaseEntity
    {
        public string PrimeiroNome { get; set; }
        public string SobreNome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
