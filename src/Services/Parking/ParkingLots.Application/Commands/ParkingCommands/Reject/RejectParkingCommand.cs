using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkingLots.Application.Specifications.ParkingSpecs;
using ParkingLots.Domain.Interfaces.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.Aplication.Commands.Reserve
{
    public class RejectParkingCommand : IRequest
    {
        public int Number { get; }
        public RejectParkingCommand(int number)
        {
            Number = number; ;
        }
    }

    // ReSharper disable once UnusedType.Global
    public class RejectOrderCommandHandler : IRequestHandler<RejectParkingCommand>
    {
        IRepository _repository;

        public RejectOrderCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RejectParkingCommand request, CancellationToken cancellationToken)
        {
            var parkings = await _repository.ListAsync(new GetParkingByNumberSpec(request.Number));
            var parking = parkings.FirstOrDefault();

            parking.Available = true;
            parking.ReservedAt = default(DateTime);
            parking.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(parking);

            return Unit.Value;
        }
    }
}
