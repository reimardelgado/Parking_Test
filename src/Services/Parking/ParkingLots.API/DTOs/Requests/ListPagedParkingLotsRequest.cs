using ParkingLots.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingLots.API.DTOs.Requests
{

    public class ListPagedParkingLotsRequest : BaseRequest
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? Number { get; set; }
    }
}
