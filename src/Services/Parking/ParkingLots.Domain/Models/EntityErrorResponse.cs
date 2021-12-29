using System.Collections.Generic;

namespace ParkingLots.Domain.Models
{
    public class EntityErrorResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}