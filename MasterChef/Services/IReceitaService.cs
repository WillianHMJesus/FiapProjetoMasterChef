using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IReceitaService
    {
        void Adicionar(Receita receita);
        void Atualizar(Receita receita);
        void Deletar(int receitaId);
        Receita ObterPorId(int receitaId);
        IList<Receita> ObterTodos();
    }
}
