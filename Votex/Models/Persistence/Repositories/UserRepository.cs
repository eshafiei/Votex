using System;
using System.Linq;
using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public User GetUserByUserId(string userId)
        {
            return VotexContext.Users.SingleOrDefault(u => u.Id == userId);
        }
    }
}