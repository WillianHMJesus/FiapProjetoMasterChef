using System;

namespace Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public string Nome { get; set; }
        public string ComentarioTexto { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
    }
}
