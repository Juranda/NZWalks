using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class StaticUserRepository : IUserRepository
    {
        List<User> Users = new List<User>
        {
            //new User
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Fulanin",
            //    LastName = "Detal",
            //    EmailAddress = "deTalPadrao@gmail.com",
            //    Password = "1234",
            //    Username = "xXFULANINXx",
            //    Roles = new() {"reader"}
            //},
            //new User
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Catarina",
            //    LastName = "Foagraça",
            //    EmailAddress = "vanda.game@ethera.com.br",
            //    Password = "velinsvaliosos",
            //    Username = "Catarina F.",
            //    Roles = new() {"reader", "writer"}
            //}
        };

        public Task<User> Authenticate(string username, string password)
        {
            return Task.FromResult(Users.Find(x => x.Username == username && x.Password == password));
        }
    }
}
