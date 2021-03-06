﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accessor.Planner.API.Application.Model.ViewModel
{
    public class SolicitationViewModel
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid? ProviderId { get; set; }
        public int Status { get; set; }
        public List<RoomViewModel> Rooms { get; set; }

    }
}
