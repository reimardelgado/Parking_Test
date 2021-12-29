using Ardalis.Specification;
using ParkingLots.Domain.Entities;
using ParkingLots.Domain.Extensions;

namespace ParkingLots.Application.Specifications.ApplicationUserSpecs
{
    sealed class ApplicationUserByUsernameAndPasswordSpec : Specification<ApplicationUser>
    {
        public ApplicationUserByUsernameAndPasswordSpec(string userName, string password)
        {
            var md5 = password.ToMd5Hash();

            Query
                .Where(user => user.UserName.Equals(userName) && user.Password.Equals(md5))
                .Include(b => b.UserProfiles);
        }
    }
}