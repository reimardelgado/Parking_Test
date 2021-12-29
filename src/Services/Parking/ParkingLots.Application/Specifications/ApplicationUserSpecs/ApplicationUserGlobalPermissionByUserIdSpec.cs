using System;
using Ardalis.Specification;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Application.Specifications.ApplicationUserSpecs
{
    public sealed class ApplicationUserGlobalPermissionByUserIdSpec : Specification<UserGlobalPermission>
    {
        public ApplicationUserGlobalPermissionByUserIdSpec(Guid userId)
        {
            Query
                .Where(permission => permission.ApplicationUserId == userId);
        }
    } 
}

