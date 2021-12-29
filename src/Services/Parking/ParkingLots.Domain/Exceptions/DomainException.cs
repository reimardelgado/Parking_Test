using System;
using System.Net;

namespace ParkingLots.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public HttpStatusCode? HttpStatusCode { get; }
        
        public DomainException(string message)
            : base(message)
        { }

        public DomainException(string message, HttpStatusCode? httpStatusCode)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public DomainException(string message, HttpStatusCode? httpStatusCode, Exception innerException)
            : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }
    } 
}

