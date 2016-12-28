using System.ComponentModel.DataAnnotations;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class ElectoralDistrict : AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
    }
}