using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Receita : BaseEntity
    {
        private ICollection<Comentario> _comentarios;
        private ICollection<ReceitaCategoria> _receitaCategorias;
        public string Nome { get; set; }
        public string TempoPreparo { get; set; }
        public int RendimentoPorcoes { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Cobertura { get; set; }
        public string InfoAdicional { get; set; }
        public string CaminhoImagem { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual ICollection<Comentario> Comentarios
        {
            get { return _comentarios ?? (_comentarios = new List<Comentario>()); }
            protected set { _comentarios = value; }
        }
        public virtual ICollection<ReceitaCategoria> ReceitasCategorias
        {
            get { return _receitaCategorias ?? (_receitaCategorias = new List<ReceitaCategoria>()); }
            protected set { _receitaCategorias = value; }
        }
    }
}
