using System.Collections.Generic;
using Domain.Entities;
using Domain;
using System.Linq;

namespace Services
{
    public class ReceitaService : IReceitaService
    {
        private IRepository<Receita> _receitaRepository;
        private IRepository<ReceitaCategoria> _receitaCategoriaRepository;
        private IRepository<Comentario> _comentarioRepository;

        public ReceitaService(IRepository<Receita> receitaRepository,
            IRepository<ReceitaCategoria> receitaCategoriaRepository,
            IRepository<Comentario> comentarioRepository)
        {
            _receitaRepository = receitaRepository;
            _receitaCategoriaRepository = receitaCategoriaRepository;
            _comentarioRepository = comentarioRepository;
        }

        public void AdicionarOuAtualizarReceita(Receita receita)
        {
            if (receita.Id == 0)
                _receitaRepository.Insert(receita);
            else
                _receitaRepository.Update(receita);
        }

        public void AdicionarOuAtualizarReceitaCategoria(ReceitaCategoria receitaCategoria)
        {
            if (receitaCategoria.Id == 0)
                _receitaCategoriaRepository.Insert(receitaCategoria);
            else
                _receitaCategoriaRepository.Update(receitaCategoria);
        }

        public void DeletarReceita(int receitaId)
        {
            var receita = _receitaRepository.GetById(receitaId);
            _receitaRepository.Delete(receita);
        }

        public void DeletarReceitaCategoria(int receitaCategoriaId)
        {
            var receitaCategoria = _receitaCategoriaRepository.GetById(receitaCategoriaId);
            _receitaCategoriaRepository.Delete(receitaCategoria);
        }

        public IList<ReceitaCategoria> GetReceitaCategoriasPorCategoriaId(int categoriaId)
        {
            return _receitaCategoriaRepository.GetAll().Where(x => x.CategoriaId == categoriaId).ToList();
        }

        public IList<ReceitaCategoria> GetReceitaCategoriasPorReceitaId(int receitaId)
        {
            return _receitaCategoriaRepository.GetAll().Where(x => x.ReceitaId == receitaId).ToList();
        }

        public IList<Comentario> GetReceitaComentariosPorReceitaId(int receitaId)
        {
            return _comentarioRepository.GetAll().Where(x => x.Receita.Id == receitaId).ToList();
        }

        public Receita GetReceitaPorId(int receitaId)
        {
            return _receitaRepository.GetById(receitaId);
        }

        public IList<Receita> GetTodosReceita()
        {
            return _receitaRepository.GetAll();
        }
    }
}
