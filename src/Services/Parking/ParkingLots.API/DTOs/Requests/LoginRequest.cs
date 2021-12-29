using ParkingLots.Domain.Models;

namespace ParkingLots.API.DTOs.Requests
{
    public class LoginRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}