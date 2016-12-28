using System.Collections.Generic;
using System.Linq;
using Votex.Models.Core.Domain;
using Votex.Models.Core.Repositories;
using Votex.Models.Dto;

namespace Votex.Models.Persistence.Repositories
{
    public class IssueRepository : Repository<Issue>, IIssueRepository
    {
        public IssueRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext VotexContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<Issue> GetIssues(string query = null)
        {
            var issuesQuery = VotexContext.Issues.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                issuesQuery = issuesQuery.Where(c => c.Question.Contains(query));
            }

            return issuesQuery;
        }

        public IEnumerable<IssueDto> GetSelectedIssues(int id)
        {
            var ballotIssues = VotexContext.BallotIssues.Where(b => b.BallotId == id);
            var issueDtos = new List<IssueDto>();

            foreach (var ballotIssue in ballotIssues)
            {
                var issue = VotexContext.Issues.SingleOrDefault(e => e.Id == ballotIssue.IssueId);
                if (issue != null)
                {
                    var issueDto = new IssueDto
                    {
                        IssueId = ballotIssue.IssueId,
                        BallotId = ballotIssue.BallotId,
                        Question = issue.Question
                    };
                    issueDtos.Add(issueDto);
                }
            }
            return issueDtos;
        }
    }
}