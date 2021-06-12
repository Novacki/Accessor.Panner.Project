﻿using Accessor.Planner.API.Application.Model.ViewModel;
using Accessor.Planner.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accessor.Planner.API.Application.Extensions
{
    public static class TransformDataSolicitation
    {
        public static SolicitationViewModel ToViewModel(this Solicitation solicitation)
        {
            return new SolicitationViewModel()
            {
                Id = solicitation.Id,
                AccessorId = solicitation.AccessorId,
                CreatedAt = solicitation.CreatedAt,
                UpdatedAt = solicitation.UpdatedAt,
                Provider = solicitation.Provider == null ? null : solicitation.Provider.ToFullViewModel(),
                Client = solicitation.Client.ToFullViewModel(),
                Status = (int)solicitation.Status,
                SolicitationEndDate = solicitation.SolicitationEndDate,
                Rooms = solicitation.Rooms.ToViewModel(),
                SolicitationHistories = solicitation.SolicitationHistories.ToViewModel()

            };
        }

        public static List<SolicitationViewModel> ToViewModel(this List<Solicitation> solicitations)
        {
            return solicitations.Select(s => new SolicitationViewModel()
            {
                Id = s.Id,
                AccessorId = s.AccessorId,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt,
                Provider = s.Provider == null ? null : s.Provider.ToFullViewModel(),
                Client = s.Client.ToFullViewModel(),
                Status = (int)s.Status,
                SolicitationEndDate = s.SolicitationEndDate,
                Rooms = s.Rooms.ToViewModel(),
                SolicitationHistories = s.SolicitationHistories.ToViewModel()

            }).ToList();
            
        }
    }
}
