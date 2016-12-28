using System;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVoterRepository Voters { get; }
        IPoliticalPartyRepository PoliticalParties { get; }
        ICandidateRepository Candidates { get; }
        IElectoralDistrictRepository ElectoralDistricts { get; }
        IIssueRepository Issues { get; }
        IBallotRepository Ballots { get; }
        IElectionRepository Elections { get; }
        IBallotElectionRepository BallotElections { get; }
        IBallotIssueRepository BallotIssues { get; }
        int Complete();
    }
}