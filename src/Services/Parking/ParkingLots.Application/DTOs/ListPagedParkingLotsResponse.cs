using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLots.Application.DTOs
{

    public class ListPagedParkingLotsResponse
    {   

        public ListPagedParkingLotsResponse()
        {
        }

        public List<Parking> Parkings { get; set; } = new List<Parking>();
        public int PageCount { get; set; }
    }
}
