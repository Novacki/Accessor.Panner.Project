﻿using Accessor.Planner.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accessor.Planner.Domain.Interface
{
    public interface ISolicitationService : IBaseService<Solicitation>
    {
        Task Create(Guid userId, List<Room> rooms);
        Solicitation GetById(Guid id);
        Task<List<Solicitation>> GetByUserAsync(Guid userId);
        Task Accept(Guid userId, Guid solicitationId);
        Task Send(Guid userId, Guid solicitationId);
        Task Approve(Guid userId, Guid solicitationId);
        Task Reject(Guid userId, Guid solicitationId, string reason);
        Task Cancel(Guid userId, Guid solicitationId, string reason);
    }
}
