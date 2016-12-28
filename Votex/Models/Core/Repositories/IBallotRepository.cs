using System.Collections.Generic;
using Votex.Models.Core.Domain;

namespace Votex.Models.Core.Repositories
{
    public interface IBallotRepository : IRepository<Ballot>
    {
        IEnumerable<int> GetElectionsByBallotId(int id);
        IEnumerable<int> GetIssuesByBallotId(int id);
        void RemoveBallotElectionsByBallotId(int id);
        void RemoveBallotIssuesByBallotId(int id);
    }
}
