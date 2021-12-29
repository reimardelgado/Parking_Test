using System;
using System.Collections.Generic;
using Ardalis.Specification;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Specifications.PermissionSpecs
{
    public sealed class PermissionByIdsSpec : Specification<Permission>
    {
        public PermissionByIdsSpec(ICollection<Guid> ids)
        {
            Query.Where(permission => ids.Contains(permission.Id));
        }
    }
}

