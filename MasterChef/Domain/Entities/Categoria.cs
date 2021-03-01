using System.Collections.Generic;

namespace Domain.Entities
{
    public class Categoria : BaseEntity
    {
        protected Categoria()
        {

        }

        public Categoria(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
            _receitas = new List<Receita>();
        }

        private ICollection<Receita> _receitas;

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public virtual ICollection<Receita> Receitas
        {
            get { return _receitas; }
        }
    }
}
