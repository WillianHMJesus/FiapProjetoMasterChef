using System.Collections.Generic;

namespace Domain.Entities
{
    public class Categoria : Entity
    {
        protected Categoria()
        {

        }

        public Categoria(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            _receitasCategoria = new List<ReceitaCategoria>();
        }

        private ICollection<ReceitaCategoria> _receitasCategoria;

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<ReceitaCategoria> ReceitasCategoria
        {
            get { return _receitasCategoria; }
        }
    }
}
