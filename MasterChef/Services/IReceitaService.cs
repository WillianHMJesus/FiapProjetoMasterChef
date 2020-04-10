using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IReceitaService
    {
        void AdicionarOuAtualizarReceita(Receita receita);
        void DeletarReceita(int receitaId);
        Receita GetReceitaPorId(int receitaId);
        IList<Receita> GetTodosReceita();
        void AdicionarOuAtualizarReceitaCategoria(ReceitaCategoria receitaCategoria);
        void DeletarReceitaCategoria(int receitaCategoriaId);
        IList<ReceitaCategoria> GetReceitaCategoriasPorCategoriaId(int categoriaId);
        IList<ReceitaCategoria> GetReceitaCategoriasPorReceitaId(int receitaId);
        IList<Comentario> GetReceitaComentariosPorReceitaId(int receitaId);
    }
}
