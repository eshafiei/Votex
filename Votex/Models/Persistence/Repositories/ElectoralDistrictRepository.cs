using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Persistence.Repositories
{
    public class ElectoralDistrictRepository : Repository<ElectoralDistrict>, IElectoralDistrictRepository
    {
        public ElectoralDistrictRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}