using System.Collections.Generic;

namespace Domain.Entities
{
    public class Categoria : BaseEntity
    {
        private ICollection<ReceitaCategoria> _receitaCategorias;
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<ReceitaCategoria> ReceitasCategorias
        {
            get { return _receitaCategorias ?? (_receitaCategorias = new List<ReceitaCategoria>()); }
            protected set { _receitaCategorias = value; }
        }
    }
}
