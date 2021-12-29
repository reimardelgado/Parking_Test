using System;
using System.Collections.Generic;
using MediatR;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Services.Reads
{
    public class ReadUserGlobalPermissions : IRequest<ICollection<UserGlobalPermission>>
    {
        public Guid UserId { get; }

        public ReadUserGlobalPermissions(Guid userId)
        {
            UserId = userId;
        }
    }
}

