using System;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class ProfilePermission : BaseEntity, IAggregateRoot
    {
        #region Constructor & properties

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }

        protected ProfilePermission()
        {
            Id = Guid.NewGuid();
        }

        public ProfilePermission(Guid profileId, Guid permissionId) : this()
        {
            ProfileId = profileId;
            PermissionId = permissionId;
        }

        #endregion
    }
}