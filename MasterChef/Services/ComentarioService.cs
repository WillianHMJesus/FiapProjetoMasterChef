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

        public void AdicionarOuAtualizarComentario(Comentario comentario)
        {
            if (comentario.Id == 0)
                _comentarioRepository.Insert(comentario);
            else
                _comentarioRepository.Update(comentario);
        }

        public void DeletarComentario(int comentarioId)
        {
            var comentario = _comentarioRepository.GetById(comentarioId);
            _comentarioRepository.Delete(comentario);
        }

        public Comentario GetComentarioPorId(int comentarioId)
        {
            return _comentarioRepository.GetById(comentarioId);
        }

        public IList<Comentario> GetTodosComentarios()
        {
            return _comentarioRepository.GetAll();
        }
    }
}
