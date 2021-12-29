using Ardalis.Specification;
using ParkingLots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLots.Application.Specifications.ParkingSpecs
{
    public class GetPaginateParkingSpec: Specification<Parking>
    {
        public GetPaginateParkingSpec(int skip, int take, int? number)
        {           

            if (take == 0)
            {
                take = int.MaxValue;
            }
            Query
                .Where(parking => (!number.HasValue || parking.Number == number)).Paginate(skip, take);
        }
    }
}
