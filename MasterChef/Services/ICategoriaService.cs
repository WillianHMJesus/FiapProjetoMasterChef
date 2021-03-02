using Domain.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface ICategoriaService
    {
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        void Deletar(int categoriaId);
        Categoria ObterPorId(int categoriaId);
        IList<Categoria> ObterTodos();
    }
}
