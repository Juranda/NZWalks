using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NZWalkDbContext context;

        public UserRepository(NZWalkDbContext context)
        {
            this.context = context;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username && user.Password == password);

            if (user is null) return user;

            var user_Roles = await context.User_Roles.Where(ur => ur.UserId == user.Id).ToListAsync();

            if (!user_Roles.Any()) return user;

            user.Roles = new List<string>();

            foreach (var userRole in user_Roles)
            {
                var role = await context.Roles.FirstOrDefaultAsync(r => r.Id == userRole.RoleId);

                Console.WriteLine(role.Name);
                if (role is null) continue;

                user.Roles.Add(role.Name);
            }

            return user;
        }
    }
}
