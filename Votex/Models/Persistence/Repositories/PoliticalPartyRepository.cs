using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Persistence.Repositories
{
    public class PoliticalPartyRepository : Repository<PoliticalParty>, IPoliticalPartyRepository
    {
        public PoliticalPartyRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}