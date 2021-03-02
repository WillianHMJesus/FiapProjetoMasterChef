using System.Collections.Generic;
using Domain.Entities;
using Domain;
using System.Linq;

namespace Services
{
    public class ReceitaService : IReceitaService
    {
        private IRepository<Receita> _receitaRepository;

        public ReceitaService(IRepository<Receita> receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public void Adicionar(Receita receita)
        {
            _receitaRepository.Adicionar(receita);
        }

        public void Atualizar(Receita receita)
        {
            _receitaRepository.Atualizar(receita);
        }

        public void Deletar(int receitaId)
        {
            var receita = _receitaRepository.ObterPorId(receitaId);
            _receitaRepository.Deletar(receita);
        }

        public Receita ObterPorId(int receitaId)
        {
            return _receitaRepository.ObterPorId(receitaId);
        }

        public IList<Receita> ObterTodos()
        {
            return _receitaRepository.ObterTodos();
        }
    }
}
