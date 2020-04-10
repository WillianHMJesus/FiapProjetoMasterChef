using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface ICategoriaService
    {
        void AdicionarOuAtualizarCategoria(Categoria categoria);
        void DeletarCategoria(int categoriaId);
        Categoria GetCategoriaPorId(int categoriaId);
        IList<Categoria> GetTodosCategoria();
        void AdicionarOuAtualizarReceitaCategoria(ReceitaCategoria receitaCategoria);
        void DeletarReceitaCategoria(int receitaCategoriaId);
        IList<ReceitaCategoria> GetReceitaCategoriasPorCategoriaId(int categoriaId);
        IList<ReceitaCategoria> GetReceitaCategoriasPorReceitaId(int receitaId);
    }
}
