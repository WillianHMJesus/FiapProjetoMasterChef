using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        private readonly IDbContext _context;
        private DbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            _context = context;
        }

        public void Adicionar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Add(entity);

            _context.SaveChanges();
        }

        public void Atualizar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Update(entity);
            _context.SaveChanges();
        }

        public void Deletar(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Remove(entity);

            _context.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return Entities.Find(id);
        }

        public List<T> ObterTodos()
        {
            return Entities.ToList();
        }

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
    }
}
