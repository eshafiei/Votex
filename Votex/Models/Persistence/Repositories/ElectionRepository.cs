using System.Collections.Generic;
using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;
using System.Linq;
using Votex.Models.Dto;
using WebGrease.Css.Extensions;

namespace Votex.Models.Persistence.Repositories
{
    public class ElectionRepository : Repository<Election>, IElectionRepository
    {
        public ElectionRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<Election> GetElections(string query = null)
        {
            var electionsQuery = VotexContext.Elections.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                electionsQuery = electionsQuery.Where(c => c.Office.Contains(query));
            }

            return electionsQuery;
        }


        public IEnumerable<ElectionDto> GetSelectedElections(int id)
        {
            var ballotElections = VotexContext.BallotElections.Where(b => b.BallotId == id);
            var electionDtos = new List<ElectionDto>();

            foreach (var ballotElection in ballotElections)
            {
                var election = VotexContext.Elections.SingleOrDefault(e => e.Id == ballotElection.ElectionId);
                if (election != null)
                {
                    var electionDto = new ElectionDto
                    {
                        ElectionId = ballotElection.ElectionId,
                        BallotId = ballotElection.BallotId,
                        Office = election.Office
                    };
                    electionDtos.Add(electionDto);    
                }
            }
            return electionDtos;            
        }
    }
}