using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class Candidate : AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(80)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public int VoteCount { get; set; }

        public int PoliticalPartyId { get; set; }

        [ForeignKey("PoliticalPartyId")]
        public virtual PoliticalParty PoliticalParty { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {

                return FirstName + " " + MiddleName + " " + LastName;
            }
        }
    }
}
