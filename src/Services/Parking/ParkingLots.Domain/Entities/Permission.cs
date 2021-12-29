using System;
using System.Collections.Generic;
using ParkingLots.Domain.Interfaces;

namespace ParkingLots.Domain.Entities
{
    public class Permission : BaseEntity, IAggregateRoot
    {
        #region Constructor & properties

        public string Code { get; set; }
        public string Description { get; set; }
        public string ResourceCode { get; set; }
        public string Type { get; set; }

        private readonly List<ProfilePermission> _profilePermissions;
        public IReadOnlyCollection<ProfilePermission> ProfilePermissions => _profilePermissions;

        private readonly List<UserGlobalPermission> _userGlobalPermissions;
        public IReadOnlyCollection<UserGlobalPermission> UserGlobalPermissions => _userGlobalPermissions;

        protected Permission()
        {
            Id = Guid.NewGuid();
            _profilePermissions = new List<ProfilePermission>();
            _userGlobalPermissions = new List<UserGlobalPermission>();
        }

        protected Permission(Guid id)
        {
            Id = id;
            _profilePermissions = new List<ProfilePermission>();
            _userGlobalPermissions = new List<UserGlobalPermission>();
        }

        public Permission(string code, string description, string resourceCode, string type)
            : this()
        {
            Code = code;
            Description = description;
            ResourceCode = resourceCode;
            Type = type;
        }

        public Permission(Guid id, string code, string description, string resourceCode, string type)
            : this(id)
        {
            Code = code;
            Description = description;
            ResourceCode = resourceCode;
            Type = type;
        }

        #endregion

        #region Public methods

        public void AddProfilePermission(Guid profileId)
        {
            var profilePermission = new ProfilePermission(profileId, Id);
            _profilePermissions.Add(profilePermission);
        }

        #endregion
    }
}