using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IComentarioService
    {
        void Adicionar(Comentario comentario);
        void Atualizar(Comentario comentario);
        void Deletar(int comentarioId);
        Comentario ObterPorId(int comentarioId);
        IList<Comentario> ObterTodos();
    }
}
