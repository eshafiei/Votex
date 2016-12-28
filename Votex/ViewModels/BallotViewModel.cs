using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Votex.Models.Core.Domain;
using Votex.Models.Dto;

namespace Votex.ViewModels
{
    public class BallotViewModel
    {
        public BallotViewModel()
        {}

        public BallotViewModel(Ballot ballot)
        {
            Id = ballot.Id;
            OpenDate = ballot.OpenDate;
            CloseDate = ballot.CloseDate;
            Approved = ballot.Approved;
            ElectoralDistrictId = ballot.ElectoralDistrictId;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name="Open Date")]
        public DateTime OpenDate { get; set; }

        [Required]
        [Display(Name = "Close Date")]
        public DateTime CloseDate { get; set; }

        [Display(Name = "Approve Ballot")]
        public bool Approved { get; set; }

        [Required]
        [Display(Name = "Electoral District")]
        public int ElectoralDistrictId { get; set; }

        public IEnumerable<ElectoralDistrict> ElectoralDistricts { get; set; }

        public IEnumerable<ElectionDto> Elections { get; set; }

        public IEnumerable<IssueDto> Issues { get; set; }

        public IEnumerable<int> SelectedElectionIds { get; set; }

        public IEnumerable<int> SelectedIssueIds { get; set; }
    }
}