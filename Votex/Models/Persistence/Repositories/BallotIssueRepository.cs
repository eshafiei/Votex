using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Persistence.Repositories
{
    public class BallotIssueRepository : Repository<BallotIssue>, IBallotIssueRepository
    {
        public BallotIssueRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}