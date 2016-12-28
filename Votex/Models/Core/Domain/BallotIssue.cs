using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class BallotIssue : AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public int BallotId { get; set; }

        [Required]
        public int IssueId { get; set; }

        [ForeignKey("BallotId")]
        public Ballot Ballot { get; set; }

        [ForeignKey("IssueId")]
        public Issue Issue { get; set; }

        public int? VoteCount { get; set; }
    }
}