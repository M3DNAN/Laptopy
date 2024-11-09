﻿using System.Linq.Expressions;

namespace Laptopy.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // CRUD
        public IQueryable<T> GetAll(Expression<Func<T, object>>[]? includeProp = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);

        T? GetOne(Expression<Func<T, object>>[]? includeProps = null, Expression<Func<T, bool>>? expression = null, bool tracked = true);

        void Create(T entity);

        void Edit(T entity);

        void Delete(T entity);

        void Commit();
    }
}