using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkingLots.API.DTOs.Requests;
using ParkingLots.Aplication.Commands.Reserve;
using ParkingLots.Application.Commands.ParkingCommand.Create;
using ParkingLots.Application.Commands.ParkingCommand.Delete;
using ParkingLots.Application.Commands.Reserve;
using ParkingLots.Application.Commands.Update;
using ParkingLots.Application.DTOs;
using ParkingLots.Application.Queries.ParkingQueries;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Models;
using ParkingLots.Infrastructure;
using ParkingLots.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLots.API.Controllers
{
    public class ParkingController : BaseController
    {
        #region Contructor && Properties

        private readonly IMediator _mediator;

        public ParkingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        [HttpGet]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces(typeof(ListPagedParkingLotsResponse))]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> GetParkings([FromQuery] ListPagedParkingLotsRequest queryParams,
            CancellationToken cancellationToken)
        {
            var parkings = await _mediator.Send(
                new ReadParkingLotsQuery(queryParams.Number, queryParams.PageSize, queryParams.PageIndex),
                cancellationToken);

            return Ok(parkings);
        }

        [HttpGet("{number}")]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces(typeof(ListPagedParkingLotsResponse))]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> GetParking(int number, CancellationToken token)
        {
            var parking = await _mediator.Send(
                new GetParkingByIdQuery { Number = number },
                token
            );

            return Ok(parking);
        }

        [HttpPost]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [Produces(typeof(Parking))]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> CreateParking([FromBody] CreateParkingCommand command,
            CancellationToken cancellationToken)
        {
            var parking = await _mediator.Send(command, cancellationToken);

            return Ok(parking);
        }

        [HttpDelete("{number}")]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]        
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> DeleteParking(int number)
        {
            await _mediator.Send(new DeleteParkingCommand { Number = number });

            return NoContent();
        }

        [HttpPut("{number}")]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> UpdateParking(int number, [FromBody] UpdateParkingCommand command)
        {
            command.Number = number;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{number}/reserve")]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> ReserveParking(int number, CancellationToken token)
        {
            var command = new ReserveParkingCommand(number);
            await _mediator.Send(command, token);

            return Ok();
        }

        [HttpGet("{number}/reject")]
        [JwtAuthorize(JwtScope.Member, "Users:Profiles:ReadOnlyAccess Parking:Parking:FullAccess")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesErrorResponseType(typeof(EntityErrorResponse))]
        public async Task<IActionResult> RejectParking(int number, CancellationToken token)
        {
            var command = new RejectParkingCommand(number);
            await _mediator.Send(command, token);

            return Ok();
        }
    }
}
