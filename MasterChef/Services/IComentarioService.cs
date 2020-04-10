using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IComentarioService
    {
        void AdicionarOuAtualizarComentario(Comentario comentario);
        void DeletarComentario(int comentarioId);
        Comentario GetComentarioPorId(int comentarioId);
        IList<Comentario> GetTodosComentarios();
    }
}
