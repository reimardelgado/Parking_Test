using System;
using System.Collections.Generic;
using MediatR;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Services.Reads
{
    public class ReadPermissionsService : IRequest<ICollection<Permission>>
    {
        public ICollection<Guid> Ids { get; }

        public ReadPermissionsService(ICollection<Guid> ids)
        {
            Ids = ids;
        }
    }
}

