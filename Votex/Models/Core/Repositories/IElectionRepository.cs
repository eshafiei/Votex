using System.Collections.Generic;
using Votex.Models.Core.Domain;
using Votex.Models.Dto;

namespace Votex.Models.Core.Repositories
{
    public interface IElectionRepository : IRepository<Election>
    {
        IEnumerable<Election> GetElections(string query = null);
        IEnumerable<ElectionDto> GetSelectedElections(int id);
    }
}
