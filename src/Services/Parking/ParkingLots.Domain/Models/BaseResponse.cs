using System;

namespace ParkingLots.Domain.Models
{
    /// <summary>
    /// Base class used by API responses
    /// </summary>
    public abstract class BaseResponse<T> : BaseMessage
    {
        public T Value { get; set; }
        public bool IsSuccess { get; set; } = true;

        public BaseResponse(Guid correlationId) : this()
        {
            _correlationId = correlationId;
        }

        public BaseResponse()
        {
        }
    } 
}

