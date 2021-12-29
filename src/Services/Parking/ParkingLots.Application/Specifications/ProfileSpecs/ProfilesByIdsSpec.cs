using System;
using System.Collections.Generic;
using Ardalis.Specification;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Specifications.ProfileSpecs
{
    public sealed class ProfilesByIdsSpec : Specification<Profile>
    {
        public ProfilesByIdsSpec(ICollection<Guid> ids)
        {
            Query
                .Where(profile => ids.Contains(profile.Id))
                .Include(profile => profile.ProfilePermissions)
                .ThenInclude(permission => permission.Permission);
        }
    }
}