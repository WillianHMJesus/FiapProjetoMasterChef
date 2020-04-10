using System.Collections.Generic;
using Domain.Entities;
using Domain;
using System.Linq;

namespace Services
{
    public class CategoriaService : ICategoriaService
    {
        private IRepository<Categoria> _categoriaRepository;
        private IRepository<ReceitaCategoria> _receitaCategoriaRepository;

        public CategoriaService(IRepository<Categoria> categoriaRepository,
            IRepository<ReceitaCategoria> receitaCategoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            _receitaCategoriaRepository = receitaCategoriaRepository;
        }

        public void AdicionarOuAtualizarCategoria(Categoria categoria)
        {
            if (categoria.Id == 0)
                _categoriaRepository.Insert(categoria);
            else
                _categoriaRepository.Update(categoria);
        }

        public void AdicionarOuAtualizarReceitaCategoria(ReceitaCategoria receitaCategoria)
        {
            if (receitaCategoria.Id == 0)
                _receitaCategoriaRepository.Insert(receitaCategoria);
            else
                _receitaCategoriaRepository.Update(receitaCategoria);
        }

        public void DeletarCategoria(int categoriaId)
        {
            var categoria = _categoriaRepository.GetById(categoriaId);
            _categoriaRepository.Delete(categoria);
        }

        public void DeletarReceitaCategoria(int receitaCategoriaId)
        {
            var receitaCategoria = _receitaCategoriaRepository.GetById(receitaCategoriaId);
            _receitaCategoriaRepository.Delete(receitaCategoria);
        }

        public Categoria GetCategoriaPorId(int categoriaId)
        {
            return _categoriaRepository.GetById(categoriaId);
        }

        public IList<ReceitaCategoria> GetReceitaCategoriasPorCategoriaId(int categoriaId)
        {
            return _receitaCategoriaRepository.GetAll().Where(x => x.CategoriaId == categoriaId).ToList();
        }

        public IList<ReceitaCategoria> GetReceitaCategoriasPorReceitaId(int receitaId)
        {
            return _receitaCategoriaRepository.GetAll().Where(x => x.ReceitaId  == receitaId).ToList();
        }

        public IList<Categoria> GetTodosCategoria()
        {
            return _categoriaRepository.GetAll();
        }
    }
}
