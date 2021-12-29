namespace ParkingLots.Infrastructure.Security
{
    public class JwtAuthenticationSettings
    {
        public string Key { get; set; }
        public string TokenName { get; set; }
        public long ExpireHours { get; set; }
    }
}