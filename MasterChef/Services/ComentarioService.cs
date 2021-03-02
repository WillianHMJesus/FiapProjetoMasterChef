using System.Collections.Generic;
using Domain.Entities;
using Domain;

namespace Services
{
    public class ComentarioService : IComentarioService
    {
        private IRepository<Comentario> _comentarioRepository;

        public ComentarioService(IRepository<Comentario> comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public void Adicionar(Comentario comentario)
        {
            _comentarioRepository.Adicionar(comentario);
        }

        public void Atualizar(Comentario comentario)
        {
            _comentarioRepository.Atualizar(comentario);
        }

        public void Deletar(int comentarioId)
        {
            var comentario = _comentarioRepository.ObterPorId(comentarioId);
            _comentarioRepository.Deletar(comentario);
        }

        public Comentario ObterPorId(int comentarioId)
        {
            return _comentarioRepository.ObterPorId(comentarioId);
        }

        public IList<Comentario> ObterTodos()
        {
            return _comentarioRepository.ObterTodos();
        }
    }
}
