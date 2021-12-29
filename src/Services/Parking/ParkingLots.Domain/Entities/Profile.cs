using System;
using System.Collections.Generic;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class Profile : BaseEntity, IAggregateRoot
    {
        #region Constructor & properties

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        private readonly List<ProfilePermission> _profilePermissions;
        public IReadOnlyCollection<ProfilePermission> ProfilePermissions => _profilePermissions;


        protected Profile()
        {
            Id = Guid.NewGuid();
            _profilePermissions = new List<ProfilePermission>();
        }

        protected Profile(Guid id)
        {
            Id = id;
            _profilePermissions = new List<ProfilePermission>();
        }

        public Profile(string name, string description)
            : this()
        {
            SetName(name);
            SetDescription(description);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Profile(Guid id, string name, string description)
            : this(id)
        {
            SetName(name);
            SetDescription(description);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        #endregion

        #region Setters

        public void SetName(string value)
        {
            Name = value;
        }

        public void SetDescription(string value)
        {
            Description = value;
        }

        public void SetUpdateAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetDeleteAt()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        #endregion

        #region Public methods

        public void AddProfilePermission(Guid permissionId)
        {
            var profilePermission = new ProfilePermission(Id, permissionId);
            _profilePermissions.Add(profilePermission);
        }

        #endregion
    }
}