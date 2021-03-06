﻿using Accessor.Planner.Domain.Data.Repository;
using Accessor.Planner.Domain.Model;
using Accessor.Planner.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessor.Planner.Infrastructure.Repository
{
    public class SolicitationRepository : Repository<Solicitation>, ISolicitationRepository
    {
        public SolicitationRepository(ApplicationDataContext context) : base(context) { }


        public override IQueryable<Solicitation> GetAll()
        {
            return base.GetAll()
                .Include(s => s.Provider)
                .Include(s => s.Client)
                .Include(s => s.Rooms);
        }

        public override async Task<Solicitation> GetByIdAsync(Guid id)
        {
            return await _entities.Include(s => s.Provider).Include(s => s.Client)
                .Include(s => s.Rooms).FirstOrDefaultAsync(s => s.Id == id);
        }

        public override Solicitation GetById(Guid id)
        {
            return  _entities.Include(s => s.Provider).Include(s => s.Client)
               .Include(s => s.Rooms).FirstOrDefault(s => s.Id == id);
        }

        public async  Task<List<Solicitation>> GetByUserAsync(Guid id)
        {
            return await _entities.Where(s => s.ClientId == id).Include(s => s.Rooms).Include(s => s.Provider).Include(s => s.Client).ToListAsync();
        }
    }
}
