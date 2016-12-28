using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Votex.Models.Persistence.Repositories;

namespace Votex.Models.Core.Domain
{
    public class BallotElection: AuditableEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public int BallotId { get; set; }

        [Required]
        public int ElectionId { get; set; }

        [ForeignKey("BallotId")]
        public Ballot Ballot { get; set; }

        [ForeignKey("ElectionId")]
        public Election Election { get; set; }

        public int? VoteCount { get; set; }
    }
}