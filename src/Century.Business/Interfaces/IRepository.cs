using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Century.Business.Models;

namespace Century.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity); // método que adiciona qualquer informação que seja filha de Entity
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task Remover(Guid id);
        //Bucar entidade por qualquer parâmetro
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);        
        Task<int> SaveChanges();
    }
}
