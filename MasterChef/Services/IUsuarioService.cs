using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IUsuarioService
    {
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Deletar(int usuarioId);
        Usuario ObterPorId(int usuarioId);
        IList<Usuario> ObterTodos();
    }
}
