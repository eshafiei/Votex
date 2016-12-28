using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Votex.Models.Core.Domain;

namespace Votex.ViewModels
{
    public class CandidateViewModel
    {
        public CandidateViewModel()
        {
            Id = 0;
        }

        public CandidateViewModel(Candidate candidate)
        {
            FirstName = candidate.FirstName;
            MiddleName = candidate.MiddleName;
            LastName = candidate.LastName;
            PoliticalPartyId = candidate.PoliticalPartyId;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int VoteCount { get; set; }

        [Display(Name = "Political Party")]
        public int PoliticalPartyId { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + MiddleName + " " + LastName;
            }
        }

        public IEnumerable<PoliticalParty> PoliticalParties { get; set; }

    }
}