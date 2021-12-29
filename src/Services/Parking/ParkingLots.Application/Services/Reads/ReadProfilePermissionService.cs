using System;
using System.Collections.Generic;
using MediatR;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Services.Reads
{
    public class ReadProfilePermissionService : IRequest<ICollection<ProfilePermission>>
    {
        public List<Guid> ProfilesIds { get; }

        public ReadProfilePermissionService(List<Guid> profilesIds)
        {
            ProfilesIds = profilesIds;
        }
    }
}