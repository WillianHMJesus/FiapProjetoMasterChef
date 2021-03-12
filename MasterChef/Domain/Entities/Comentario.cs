using System;

namespace Domain.Entities
{
    public class Comentario : Entity
    {
        protected Comentario()
        {

        }

        public Comentario(string nome, string texto)
        {
            Nome = nome;
            Texto = texto;
            Criacao = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Texto { get; private set; }
        public DateTime Criacao { get; private set; }
        public Receita Receita { get; private set; }
    }
}
