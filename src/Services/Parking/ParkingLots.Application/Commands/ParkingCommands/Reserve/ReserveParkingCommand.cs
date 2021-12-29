using MediatR;
using ParkingLots.Application.Specifications.ParkingSpecs;
using ParkingLots.Domain.Interfaces.Repositories;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.Application.Commands.Reserve
{
    public class ReserveParkingCommand : IRequest
    {
        public int Number { get; }
        public ReserveParkingCommand(int number)
        {
            Number = number; ;
        }
    }

    // ReSharper disable once UnusedType.Global
    public class ReserveOrderCommandHandler : IRequestHandler<ReserveParkingCommand>
    {
        IRepository _repository;

        public ReserveOrderCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ReserveParkingCommand request, CancellationToken cancellationToken)
        {
            var parkings = await _repository.ListAsync(new GetParkingByNumberSpec(request.Number));
            var parking = parkings.FirstOrDefault();

            parking.Available = false;
            parking.ReservedAt = DateTime.Now;
            parking.UpdatedAt = DateTime.Now;

            await _repository.UpdateAsync(parking);

            return Unit.Value;
        }
    }
}
