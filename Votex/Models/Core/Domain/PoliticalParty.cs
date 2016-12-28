using System.ComponentModel.DataAnnotations;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class PoliticalParty : AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}