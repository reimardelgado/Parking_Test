using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ParkingLots.Application.Specifications.ApplicationUserSpecs;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;

namespace ParkingLots.Application.Services.Reads
{
    public class ReadUserGlobalPermissionsHandler 
        : IRequestHandler<ReadUserGlobalPermissions, ICollection<UserGlobalPermission>>
    {
        private readonly IRepository _repos;

        public ReadUserGlobalPermissionsHandler(IRepository repos)
        {
            _repos = repos;
        }

        public async Task<ICollection<UserGlobalPermission>> Handle(ReadUserGlobalPermissions request,
            CancellationToken cancellationToken)
        {
            var permissions = await _repos.ListAsync(new ApplicationUserGlobalPermissionByUserIdSpec(request.UserId));

            return permissions;
        }
    }
}

