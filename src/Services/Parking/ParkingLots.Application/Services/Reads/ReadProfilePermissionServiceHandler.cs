using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ParkingLots.Application.Specifications.ProfilePermissionsSpecs;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;

namespace ParkingLots.Application.Services.Reads
{
    public class
        ReadProfilePermissionServiceHandler : IRequestHandler<ReadProfilePermissionService,
            ICollection<ProfilePermission>>
    {
        private readonly IRepository _repository;

        public ReadProfilePermissionServiceHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ProfilePermission>> Handle(ReadProfilePermissionService query,
            CancellationToken cancellationToken)
        {
            return await _repository.ListAsync(new ProfilePermissionsByIds(query.ProfilesIds));
        }
    }
}