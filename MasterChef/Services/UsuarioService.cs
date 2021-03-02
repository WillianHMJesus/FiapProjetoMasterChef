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

        public void Adicionar(Usuario usuario)
        {
            _usuarioRepository.Adicionar(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _usuarioRepository.Atualizar(usuario);
        }

        public void Deletar(int usuarioId)
        {
            var usuario = _usuarioRepository.ObterPorId(usuarioId);
            _usuarioRepository.Deletar(usuario);
        }

        public Usuario ObterPorId(int usuarioId)
        {
            return _usuarioRepository.ObterPorId(usuarioId);
        }

        public IList<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }
    }
}
