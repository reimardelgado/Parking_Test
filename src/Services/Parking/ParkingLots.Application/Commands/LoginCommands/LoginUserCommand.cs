using MediatR;
using ParkingLots.Domain.Models;

namespace ParkingLots.Application.Commands.LoginCommands
{
    public class LoginUserCommand : IRequest<EntityResponse<string>>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginUserCommand()
        {
        }

        public LoginUserCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

}