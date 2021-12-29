using System;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class Parking : BaseEntity, IAggregateRoot
    {
        public int Number { get; set; }
        public bool Available { get; set; }
        public DateTime? ReservedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}