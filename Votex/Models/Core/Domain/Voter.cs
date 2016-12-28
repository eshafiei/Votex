using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class Voter : AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime BirthDate { get; set; }

        [StringLength(10)]
        public string RegistrationId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int ElectoralDistrictId { get; set; }

        [ForeignKey("ElectoralDistrictId")]
        public virtual ElectoralDistrict ElectoralDistrict { get; set; }
    }
}