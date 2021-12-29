using System;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class UserProfile : BaseEntity, IAggregateRoot
    {
        #region Contructor && Properties

        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }

        public UserProfile()
        {
            Id = Guid.NewGuid();
        }

        #endregion
    }
}