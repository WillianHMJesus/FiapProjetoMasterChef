using System.Collections.Generic;

namespace Domain.Entities
{
    public class Receita : BaseEntity
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
            _categorias = new List<Categoria>();
        }

        private ICollection<Comentario> _comentarios;
        private ICollection<Categoria> _categorias;

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
        public virtual ICollection<Categoria> ReceitasCategorias
        {
            get { return _categorias; }
        }

        public void AdicionarComentario(Comentario comentario)
        {
            _comentarios.Add(comentario);
        }
    }
}
