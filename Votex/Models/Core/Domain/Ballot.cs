using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class Ballot : AuditableEntity<int>
    {
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }

        public DateTime CloseDate { get; set; }

        [Display(Name="Approve Ballot")]
        public bool Approved { get; set; }

        public int ElectoralDistrictId { get; set; }

        [ForeignKey("ElectoralDistrictId")]
        public virtual ElectoralDistrict ElectoralDistrict { get; set; }
    }
}