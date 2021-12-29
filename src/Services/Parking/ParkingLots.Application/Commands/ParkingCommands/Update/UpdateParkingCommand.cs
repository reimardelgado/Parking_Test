using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkingLots.Application.Specifications.ParkingSpecs;
using ParkingLots.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.Application.Commands.Update
{
    public class UpdateParkingCommand : IRequest
    {
        public int Number { get; set; }
        public bool Available { get; set; }
    }

    public class UpdateParkingCommandHandler : IRequestHandler<UpdateParkingCommand>
    {
        IRepository _repository;

        public UpdateParkingCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateParkingCommand request, CancellationToken cancellationToken)
        {
            var parkings = await _repository.ListAsync(new GetParkingByNumberSpec(request.Number));
            var parking = parkings.FirstOrDefault();

            parking.Available = request.Available;
            parking.UpdatedAt = DateTime.Now;
            if (request.Available)
            {
                parking.ReservedAt = DateTime.Now;
            }

            await _repository.UpdateAsync(parking);

            return Unit.Value;
        }
    }
}
