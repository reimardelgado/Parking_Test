using System;
using System.Collections.Generic;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class ApplicationUser : BaseEntity, IAggregateRoot
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    
        private readonly List<UserProfile> _userProfiles = new List<UserProfile>();
        public IReadOnlyCollection<UserProfile> UserProfiles => _userProfiles;
    }
}

