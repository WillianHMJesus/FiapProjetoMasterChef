using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IUsuarioService
    {
        void AdicionarOuAtualizarUsuario(Usuario usuario);
        void DeletarUsuario(int usuarioId);
        Usuario GetUsuarioPorId(int usuarioId);
        IList<Usuario> GetTodosUsuarios();
    }
}
