﻿using System;
using System.Threading.Tasks;
using Wilcommerce.Core.Common.Domain.Repository;

namespace Wilcommerce.Core.Data.EFCore.Repository
{
    /// <summary>
    /// Implementation of <see cref="IRepository"/>
    /// </summary>
    public class Repository : IRepository
    {
        /// <summary>
        /// The DbContext instance
        /// </summary>
        protected CommonContext _context;

        public Repository(CommonContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dispose all the resource used
        /// </summary>
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves all the changes made on the aggregate
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Async method. Saves all the changes made on the aggregate
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Add an aggregate to the repository
        /// </summary>
        /// <typeparam name="TModel">The aggregate's type</typeparam>
        /// <param name="model">The aggregate to add</param>
        public void Add<TModel>(TModel model) where TModel : class, Infrastructure.IAggregateRoot
        {
            try
            {
                _context.Set<TModel>().Add(model);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the aggregate based on the specified key
        /// </summary>
        /// <typeparam name="TModel">The aggregate's type</typeparam>
        /// <param name="key">The key of the aggregate to search</param>
        /// <returns>The aggregate found</returns>
        public TModel GetByKey<TModel>(Guid key) where TModel : class, Infrastructure.IAggregateRoot
        {
            try
            {
                return _context.Find<TModel>(key);
            }
            catch 
            {
                throw;
            }
        }

        /// <summary>
        /// Async method. Gets the aggregate based on the specified key
        /// </summary>
        /// <typeparam name="TModel">The aggregate's type</typeparam>
        /// <param name="key">The key of the aggregate to search</param>
        /// <returns>The aggregate found</returns>
        public async Task<TModel> GetByKeyAsync<TModel>(Guid key) where TModel : class, Infrastructure.IAggregateRoot
        {
            try
            {
                var model = await _context.FindAsync<TModel>(key);
                return model;
            }
            catch 
            {
                throw;
            }
        }
    }
}
