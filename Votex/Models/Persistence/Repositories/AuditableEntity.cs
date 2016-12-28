using System;
using System.ComponentModel.DataAnnotations;
using Votex.Models.Core.Repositories;

namespace Votex.Models.Persistence.Repositories
{
    public abstract class AuditableEntity<T> : IAuditableEntity
    {
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}
