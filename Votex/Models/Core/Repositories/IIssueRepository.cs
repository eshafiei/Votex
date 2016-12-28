using System.Collections.Generic;
using Votex.Models.Core.Domain;
using Votex.Models.Dto;

namespace Votex.Models.Core.Repositories
{
    public interface IIssueRepository : IRepository<Issue>
    {
        IEnumerable<Issue> GetIssues(string query = null);
        IEnumerable<IssueDto> GetSelectedIssues(int id);
    }
}
