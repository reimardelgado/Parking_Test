using System;
using System.Collections.Generic;
using Ardalis.Specification;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Specifications.ProfilePermissionsSpecs
{
    public sealed class ProfilePermissionsByIds : Specification<ProfilePermission>
    {
        public ProfilePermissionsByIds(ICollection<Guid> ids)
        {
            Query
                .Where(permission => ids.Contains(permission.ProfileId))
                .Include(permission => permission.Permission);
        }
    }
}