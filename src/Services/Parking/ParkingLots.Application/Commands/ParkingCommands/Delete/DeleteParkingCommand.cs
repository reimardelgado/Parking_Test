using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingLots.Domain.Interfaces.Repositories;
using ParkingLots.Application.Specifications.ParkingSpecs;

namespace ParkingLots.Application.Commands.ParkingCommand.Delete
{
    public class DeleteParkingCommand : IRequest
    {
        public int Number { get; set; }
    }

    public class DeleteParkingCommandHandler : IRequestHandler<DeleteParkingCommand>
    {
        IRepository _repository;

        public DeleteParkingCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteParkingCommand request, CancellationToken cancellationToken)
        {
            var parkings = await _repository.ListAsync(new GetParkingByNumberSpec(request.Number));
            var parking = parkings.FirstOrDefault();

            await _repository.DeleteAsync(parking);
            return Unit.Value;
        }
    }
}
