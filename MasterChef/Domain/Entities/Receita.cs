using System.Collections.Generic;

namespace Domain.Entities
{
    public class Receita : Entity
    {
        protected Receita()
        {

        }

        public Receita(
            string nome,
            string tempoPreparo,
            int redimentoPorcoes,
            string ingredientes,
            string modoPreparo,
            string cobertura,
            string informacaoAdicional,
            string diretorioImagem)
        {
            Nome = nome;
            TempoPreparo = tempoPreparo;
            RendimentoPorcoes = redimentoPorcoes;
            Ingredientes = ingredientes;
            ModoPreparo = modoPreparo;
            Cobertura = cobertura;
            InformacaoAdicional = informacaoAdicional;
            DiretorioImagem = diretorioImagem;
            _comentarios = new List<Comentario>();
            _receitaCategorias = new List<ReceitaCategoria>();
        }

        private ICollection<Comentario> _comentarios;
        private ICollection<ReceitaCategoria> _receitaCategorias;

        public string Nome { get; private set; }
        public string TempoPreparo { get; private set; }
        public int RendimentoPorcoes { get; private set; }
        public string Ingredientes { get; private set; }
        public string ModoPreparo { get; private set; }
        public string Cobertura { get; private set; }
        public string InformacaoAdicional { get; private set; }
        public string DiretorioImagem { get; private set; }
        public virtual ICollection<Comentario> Comentarios
        {
            get { return _comentarios; }
        }
        public virtual ICollection<ReceitaCategoria> ReceitasCategorias
        {
            get { return _receitaCategorias; }
        }

        public void AdicionarComentario(Comentario comentario)
        {
            _comentarios.Add(comentario);
        }
    }
}
