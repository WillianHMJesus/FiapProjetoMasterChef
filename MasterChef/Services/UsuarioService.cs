using System.Collections.Generic;
using Domain.Entities;
using Domain;

namespace Services
{
    public class UsuarioService : IUsuarioService
    {
        private IRepository<Usuario> _usuarioRepository;

        public UsuarioService(IRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AdicionarOuAtualizarUsuario(Usuario usuario)
        {
            if (usuario.Id == 0)
                _usuarioRepository.Insert(usuario);
            else
                _usuarioRepository.Update(usuario);
        }

        public void DeletarUsuario(int usuarioId)
        {
            var usuario = _usuarioRepository.GetById(usuarioId);
            _usuarioRepository.Delete(usuario);
        }

        public IList<Usuario> GetTodosUsuarios()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario GetUsuarioPorId(int usuarioId)
        {
            return _usuarioRepository.GetById(usuarioId);
        }
    }
}
