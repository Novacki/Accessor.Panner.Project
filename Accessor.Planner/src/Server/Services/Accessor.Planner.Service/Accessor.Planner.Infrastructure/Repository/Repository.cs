﻿using Accessor.Planner.Domain.Data;
using Accessor.Planner.Domain.Data.Repository;
using Accessor.Planner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessor.Planner.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDataContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(ApplicationDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }


        public virtual IUnitOfWork UnitOfWork => _context;

        public virtual async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity).ConfigureAwait(false);
        }

        public virtual void Create(T entity)
        {
            _context.Add(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entities;
        }

        public virtual T GetById(Guid id)
        {
            return _entities.Find(id);
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id).ConfigureAwait(false);
        }

        public virtual void Update(T entity)
        {
            _entities.Update(entity);
        }

    }
}
