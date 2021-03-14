﻿using Accessor.Planner.Domain.Model.Commom;
using Accessor.Planner.Domain.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accessor.Planner.Domain.Model
{
    public class Solicitation : DefaultValues<Guid>
    {
        private Solicitation() { }
        public Solicitation(Client client)
        {
            Id = Guid.NewGuid();
            Status = StatusSolicitation.OnHold;
            Client = client;
            Rooms = new List<Room>();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Activate = true;
        }

        public DateTime SolicitationEndDate { get; private set; }
        public StatusSolicitation Status { get; private set; }
        public List<Room> Rooms { get; private set; }
        public Client Client { get; private set; }
        public Guid ClientId { get; private set; }
        public Guid? AcessorId { get; private set; }
        public Provider Provider { get; private set; }
        public Guid? ProviderId { get; private set; }
    }
}
