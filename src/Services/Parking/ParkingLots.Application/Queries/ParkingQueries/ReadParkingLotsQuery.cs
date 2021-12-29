using MediatR;
using ParkingLots.Application.DTOs;
using ParkingLots.Application.Specifications.ParkingSpecs;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.Application.Queries.ParkingQueries
{
    public class ReadParkingLotsQuery : IRequest<ListPagedParkingLotsResponse>
    {
        public ReadParkingLotsQuery(int? number, int pageSize, int pageIndex)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Number = number;
        }

        public int PageSize { get; }
        public int PageIndex { get; }
        public int? Number { get; }
    }

    public class ReadParkingLotsQueryHandler : IRequestHandler<ReadParkingLotsQuery, ListPagedParkingLotsResponse>
    {
        IRepository _repository;
        public ReadParkingLotsQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListPagedParkingLotsResponse> Handle(ReadParkingLotsQuery request, CancellationToken cancellationToken)
        {
            var filterSpec = new GetParkingByNumberSpec(request.Number);
            int totalItems = await _repository.CountAsync(filterSpec);

            var pagedSpec = new GetPaginateParkingSpec(
                skip: request.PageIndex * request.PageSize,
                take: request.PageSize,
                request.Number);

            var parkings = await _repository.ListAsync(pagedSpec);

            var response = new ListPagedParkingLotsResponse();
            response.Parkings.AddRange(parkings);
            
            if (request.PageSize > 0)
            {
                response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());
            }
            else
            {
                response.PageCount = totalItems > 0 ? 1 : 0;
            }

            return response;
        }
    }
}
