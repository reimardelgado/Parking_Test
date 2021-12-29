using Ardalis.Specification;
using ParkingLots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLots.Application.Specifications.ParkingSpecs
{
    public class GetParkingByNumberSpec : Specification<Parking>
    {
        public GetParkingByNumberSpec(int? number)
        {
            Query
                .Where(parking => (!number.HasValue || parking.Number == number));
        }
    }
}
