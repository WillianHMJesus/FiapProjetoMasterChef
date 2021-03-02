using System.Collections.Generic;
using Domain.Entities;
using Domain;

namespace Services
{
    public class CategoriaService : ICategoriaService
    {
        private IRepository<Categoria> _categoriaRepository;

        public CategoriaService(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Adicionar(Categoria categoria)
        {
            _categoriaRepository.Adicionar(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _categoriaRepository.Atualizar(categoria);
        }

        public void Deletar(int categoriaId)
        {
            var categoria = _categoriaRepository.ObterPorId(categoriaId);
            _categoriaRepository.Deletar(categoria);
        }

        public Categoria ObterPorId(int categoriaId)
        {
            return _categoriaRepository.ObterPorId(categoriaId);
        }

        public IList<Categoria> ObterTodos()
        {
            return _categoriaRepository.ObterTodos();
        }
    }
}
