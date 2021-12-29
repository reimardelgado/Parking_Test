using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingLots.API.DTOs.Requests;
using ParkingLots.API.DTOs.Responses;
using ParkingLots.Application.Commands.LoginCommands;
using ParkingLots.Domain.Models;
using ParkingLots.Infrastructure.Security;

namespace ParkingLots.API.Controllers
{
    [Route("/users/auth")]
    public class LoginController : BaseController
    {
        #region Contructor && Properties

        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion
        
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Produces(typeof(LoginResponse))]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginRequest request)
        {
            var response = new LoginResponse(request.CorrelationId());

            var command = new LoginUserCommand(request.UserName, request.Password);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.EntityErrorResponse);
            }

            response.SetResponse(result);
            return Ok(response.Value);
        }
        
        [HttpGet]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces(typeof(LoginResponse))]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        [Route("prueba")]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}