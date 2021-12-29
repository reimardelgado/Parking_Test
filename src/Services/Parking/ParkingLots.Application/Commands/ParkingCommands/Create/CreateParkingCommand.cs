using MediatR;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.Application.Commands.ParkingCommand.Create
{
    public class CreateParkingCommand : IRequest<Parking>
    {
        public int Number { get; set; }
        public bool Available { get; set; }
        public DateTime ReservedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateParkingCommandHandler : IRequestHandler<CreateParkingCommand, Parking>
    {
        IRepository _repository;

        public CreateParkingCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Parking> Handle(CreateParkingCommand request, CancellationToken cancellationToken)
        {            
            var parking = new Parking
            {
                Id = Guid.NewGuid(),
                Number = request.Number,
                Available = request.Available,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                ReservedAt = default(DateTime)
            };

            var entity = await _repository.AddAsync(parking);
            return entity;
        }
    }
}
