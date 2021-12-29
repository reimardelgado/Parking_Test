using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ParkingLots.Application.Services.Reads;
using ParkingLots.Application.Specifications.ApplicationUserSpecs;
using ParkingLots.Domain.DTOs.JWT;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Interfaces.Repositories;
using ParkingLots.Domain.Interfaces.Services;
using ParkingLots.Domain.Models;

namespace ParkingLots.Application.Commands.LoginCommands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, EntityResponse<string>>
    {
        private readonly IMediator _mediator;
        private readonly IJwtTokenService _tokenService;
        private readonly IRepository _repository;

        public LoginUserCommandHandler(IMediator mediator, IJwtTokenService tokenService, IRepository repository)
        {
            _mediator = mediator;
            _tokenService = tokenService;
            _repository = repository;
        }

        public async Task<EntityResponse<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await ReadApplicationUser(request.UserName, request.Password, cancellationToken);
            if (user is null)
            {
                return EntityResponse<string>.Error("Invalid credentials");
            }
            
            var permissions = await GetPermissions(user, cancellationToken);
            var payload = new JwtPayloadDto(user.Id, user.UserName, "MEMBER", permissions);
            var token = _tokenService.GenerateJwtToken(payload);
            
            return EntityResponse.Success(token);
        }

        #region Private methods
        
        public async Task<ApplicationUser> ReadApplicationUser(string userName, string password, CancellationToken cancellationToken)
        {
            var users = await _repository.ListAsync(new ApplicationUserByUsernameAndPasswordSpec(userName, password));
            return users.FirstOrDefault();
        }

        private async Task<ICollection<string>> GetPermissions(ApplicationUser user, CancellationToken cancellationToken)
        {
            var scopedPermissions = await GetScopedPermissions(user, cancellationToken);
            var globalPermissions = await GetGlobalPermissions(user.Id, cancellationToken);
        
            var permissions = scopedPermissions.Concat(globalPermissions).Distinct().ToList();
        
            return permissions;
        }
        
        private async Task<ICollection<string>> GetGlobalPermissions(Guid userId, CancellationToken cancellationToken)
        {
            var globalPermissions = await _mediator.Send(new ReadUserGlobalPermissions(userId), cancellationToken);
            var permissionsIds = globalPermissions.Select(permission => permission.PermissionId).ToList();
        
            var permissions = await _mediator.Send(new ReadPermissionsService(permissionsIds), cancellationToken);
            var permissionsCodes = permissions.Select(permission => permission.Code);
        
            return permissionsCodes.ToList();
        }
        
        private async Task<ICollection<string>> GetScopedPermissions(ApplicationUser user, CancellationToken cancellationToken)
        {
            var profilesIds = user.UserProfiles.Select(profile => profile.ProfileId).ToList();
        
            var profilesPermissions = await _mediator.Send(new ReadProfilePermissionService(profilesIds),
                cancellationToken);
        
            var permissions = profilesPermissions.Select(permission => permission.Permission);
            var permissionCodes = permissions
                .Select(permission => permission.Code)
                .Distinct()
                .ToList();
        
            return permissionCodes;
        }

        #endregion
    }
}