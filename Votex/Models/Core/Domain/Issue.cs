using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class Issue : AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public string Question { get; set; }

        public int? YesCount { get; set; }

        public int? NoCount { get; set; }
    }
}