using System;
using System.Collections.Generic;

namespace ParkingLots.Domain.DTOs.JWT
{
    public class JwtPayloadDto
    {
        public JwtPayloadDto(Guid id, string fullname, string scope, ICollection<string> permissions)
        {
            Id = id;
            Fullname = fullname;
            Scope = scope;
            Permissions = permissions;
        }

        public Guid Id { get; }
        public string Fullname { get; }
        public string Scope { get; }
        public ICollection<string> Permissions { get; }
    }
}