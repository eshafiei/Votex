using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class Election : AuditableEntity<int>
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Office { get; set; }

        [Display(Name = "Partisan?")]
        public bool IsPartisan { get; set; }

        public int? CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual Candidate Candidate { get; set; }
    }
}