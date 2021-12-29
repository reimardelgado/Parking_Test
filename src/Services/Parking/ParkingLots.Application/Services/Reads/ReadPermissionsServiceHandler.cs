using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ParkingLots.Application.Specifications.PermissionSpecs;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;

namespace ParkingLots.Application.Services.Reads
{
    public class ReadPermissionsServiceHandler : IRequestHandler<ReadPermissionsService, ICollection<Permission>>
    {
        private readonly IRepository _repository;

        public ReadPermissionsServiceHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Permission>> Handle(ReadPermissionsService request,
            CancellationToken cancellationToken)
        {
            var permissions = await _repository.ListAsync(new PermissionByIdsSpec(request.Ids));

            return permissions;
        }
    }
}

