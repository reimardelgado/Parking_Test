using System;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class UserGlobalPermission : BaseEntity, IAggregateRoot
    {
        #region Constructor && properties

        public Guid ApplicationUserId { get; }
        public Guid PermissionId { get; }

        protected UserGlobalPermission(Guid applicationUserId)
        {
            ApplicationUserId = applicationUserId;
            Id = Guid.NewGuid();
        }

        public UserGlobalPermission(Guid applicationUserId, Guid permissionId) : this(applicationUserId)
        {
            ApplicationUserId = applicationUserId;
            PermissionId = permissionId;
        }

        #endregion
    }
}