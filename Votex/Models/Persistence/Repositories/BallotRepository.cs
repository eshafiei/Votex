using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Persistence.Repositories
{
    public class BallotRepository : Repository<Ballot>, IBallotRepository
    {
        public BallotRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<int> GetElectionsByBallotId(int id)
        {
            var selectedElections = VotexContext.BallotElections.Where(e => e.BallotId == id);
            var selectedIds = new List<int>();
            foreach (var election in selectedElections)
            {
                selectedIds.Add(election.ElectionId);
            }
            return selectedIds;
        }

        public IEnumerable<int> GetIssuesByBallotId(int id)
        {
            var selectedIssues = VotexContext.BallotIssues.Where(e => e.BallotId == id);
            var selectedIds = new List<int>();
            foreach (var issue in selectedIssues)
            {
                selectedIds.Add(issue.IssueId);
            }
            return selectedIds;
        }

        public void RemoveBallotElectionsByBallotId(int id)
        {
            var recordsToRemove = VotexContext.BallotElections.Where(b => b.BallotId == id);
            VotexContext.BallotElections.RemoveRange(recordsToRemove);
        }

        public void RemoveBallotIssuesByBallotId(int id)
        {
            var recordsToRemove = VotexContext.BallotIssues.Where(b => b.BallotId == id);
            VotexContext.BallotIssues.RemoveRange(recordsToRemove);
        }
    }
}