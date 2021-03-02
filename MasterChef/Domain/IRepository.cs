using System.Collections.Generic;

namespace Domain
{
    public interface IRepository<T> where T : class
    {
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        T ObterPorId(int id);
        List<T> ObterTodos();
    }
}
