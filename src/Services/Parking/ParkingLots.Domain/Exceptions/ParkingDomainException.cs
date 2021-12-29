using System;

namespace ParkingLots.Domain.Exceptions
{
    public class ParkingDomainException : DomainException
    {
        public ParkingDomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}