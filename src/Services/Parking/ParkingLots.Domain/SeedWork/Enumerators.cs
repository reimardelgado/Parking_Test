using System.Collections.Generic;

namespace ParkingLots.Domain.SeedWork
{
    public static class PermissionTypes
    {
        public static string Global => nameof(Global).ToLowerInvariant();
        public static string Scoped => nameof(Scoped).ToLowerInvariant();

        public static List<string> All => new List<string> { Global, Scoped };
    }
}