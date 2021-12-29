using MediatR;
using Microsoft.EntityFrameworkCore;
using ParkingLots.Application.Specifications.ParkingSpecs;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.Application.Queries.ParkingQueries
{
    public class GetParkingByIdQuery : IRequest<Parking>
    {
        public int Number { get; set; }
    }

    public class GetParkingByIdQueryHandler : IRequestHandler<GetParkingByIdQuery, Parking>
    {
        IRepository _repository;
        public GetParkingByIdQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Parking> Handle(GetParkingByIdQuery request, CancellationToken cancellationToken)
        {
            var parkings = await _repository.ListAsync(new GetParkingByNumberSpec(request.Number));               

            var parking = parkings.FirstOrDefault();

            return parking;
        }
    }
}
