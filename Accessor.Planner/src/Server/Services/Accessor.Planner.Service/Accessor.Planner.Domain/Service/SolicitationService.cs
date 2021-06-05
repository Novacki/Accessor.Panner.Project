﻿using Accessor.Planner.Domain.Data.Repository;
using Accessor.Planner.Domain.Exceptions.Service;
using Accessor.Planner.Domain.Interface;
using Accessor.Planner.Domain.Model;
using Accessor.Planner.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessor.Planner.Domain.Service
{
    public class SolicitationService : ISolicitationService
    {
        private readonly ISolicitationRepository _solicitationRepository;
        private readonly IClientService _clientService;
        private readonly ISolicitationHistoryService _solicitationHistoryService;
        public SolicitationService(ISolicitationRepository solicitationRepository, IClientService clientService, ISolicitationHistoryService solicitationHistoryService)
        {
            _solicitationRepository = solicitationRepository ?? throw new ArgumentNullException(nameof(solicitationRepository));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _solicitationHistoryService = solicitationHistoryService ?? throw new ArgumentNullException(nameof(solicitationHistoryService));
        }

        public async Task Create(Guid userId, List<Room> rooms)
        {
            var client = _clientService.GetClientByUserId(userId);

            if(client.Type != UserType.Client)
                throw new SolicitationServiceException("Accessor can't create solicitation");

            var solicitation = new Solicitation(client, rooms);
            _solicitationRepository.Create(solicitation);

            await _solicitationHistoryService.Create(new SolicitationHistory(solicitation, SubscribeType.Client));
            await _solicitationRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Accept(Guid userId, Guid solicitationId)
        {
            var client = _clientService.GetClientByUserId(userId);
            var solicitation = GetById(solicitationId);

            solicitation.AcessorAccept(client);

            await _solicitationHistoryService.Create(new SolicitationHistory(solicitation, SubscribeType.Accessor));
            await _solicitationRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Send(Guid userId, Guid solicitationId)
        {
            var client = _clientService.GetClientByUserId(userId);
            var solicitation = GetById(solicitationId);

            solicitation.Send(client);

            await _solicitationHistoryService.Create(new SolicitationHistory(solicitation, SubscribeType.Accessor));
            await _solicitationRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Approve(Guid userId, Guid solicitationId)
        {
            var client = _clientService.GetClientByUserId(userId);
            var solicitation = GetById(solicitationId);

            solicitation.Approve(client);

            await _solicitationHistoryService.Create(new SolicitationHistory(solicitation, SubscribeType.Client));
            await _solicitationRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Reject(Guid userId, Guid solicitationId, string reason)
        {
            var client = _clientService.GetClientByUserId(userId);
            var solicitation = GetById(solicitationId);

            solicitation.Reject(client, reason);

            await _solicitationHistoryService.Create(new SolicitationHistory(solicitation, SubscribeType.Client));
            await _solicitationRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Cancel(Guid userId, Guid solicitationId, string reason)
        {
            var client = _clientService.GetClientByUserId(userId);
            var solicitation = GetById(solicitationId);

            solicitation.Cancel(client, reason);
            await _solicitationHistoryService.Create(new SolicitationHistory(solicitation, SubscribeType.Client));
            await _solicitationRepository.UnitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }
       
        public List<Solicitation> GetAll() => _solicitationRepository.GetAll().ToList();

        public async Task<Solicitation> GetByIdAsync(Guid id) => await _solicitationRepository.GetByIdAsync(id).ConfigureAwait(false);

        public Solicitation GetById(Guid id) 
        {
            var solicitation = _solicitationRepository.GetById(id);

            if (solicitation == null)
                throw new SolicitationServiceException("Solicitation Not Found");

            return solicitation;
        }

        public async Task<List<Solicitation>> GetSolicitationsByUserAsync(Guid userId) => await _solicitationRepository.GetByUserAsync(userId).ConfigureAwait(false);

        public List<Solicitation> GetSolicitationsByFilter(Guid profileContextId, StatusSolicitation status, UserType? userType)
        {
            var solicitations = _solicitationRepository.GetAll().Where(s => s.Status == status);

            if(userType.Value == 0)
                throw new SolicitationServiceException("This user don't exist");

            if (userType.Value == UserType.Provider)
            {
                if (status == StatusSolicitation.Approve)
                    return solicitations.Where(s => !s.ProviderId.HasValue).ToList();

                solicitations = solicitations.Where(s => s.Provider.Id == profileContextId);
            }
            else if (userType.Value == UserType.Accessor)
            {
                if (status == StatusSolicitation.OnHold)
                    return solicitations.ToList();

                solicitations = solicitations.Where(s => s.AccessorId == profileContextId && !s.ProviderId.HasValue);
            }
            else
                solicitations = solicitations.Where(s => s.Client.Id == profileContextId);

            return solicitations.ToList();
        }

    }
}
