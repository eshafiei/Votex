using Votex.Models.Core;
using Votex.Models.Core.Repositories;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Voters = new VoterRepository(_context);
            PoliticalParties = new PoliticalPartyRepository(_context);
            Candidates = new CandidateRepository(_context);
            ElectoralDistricts = new ElectoralDistrictRepository(_context);
            Users = new UserRepository(_context);
            Issues = new IssueRepository(_context);
            Ballots = new BallotRepository(_context);
            Elections = new ElectionRepository(_context);
            BallotElections = new BallotElectionRepository(_context);
            BallotIssues = new BallotIssueRepository(_context);
        }

        public IVoterRepository Voters { get; private set; }
        public IPoliticalPartyRepository PoliticalParties { get; private set; }
        public ICandidateRepository Candidates { get; private set; }
        public IElectoralDistrictRepository ElectoralDistricts { get; private set; }
        public IUserRepository Users { get; set; }
        public IIssueRepository Issues { get; set; }
        public IBallotRepository Ballots { get; set; }
        public IElectionRepository Elections { get; set; }
        public IBallotElectionRepository BallotElections { get; set; }
        public IBallotIssueRepository BallotIssues { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}