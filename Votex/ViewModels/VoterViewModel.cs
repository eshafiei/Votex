using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Votex.Models.Core.Domain;

namespace Votex.ViewModels
{
    public class VoterViewModel
    {
        public VoterViewModel()
        { }

        public VoterViewModel(Voter voter)
        {
            Id = voter.Id;
            FirstName = voter.User.FirstName;
            LastName = voter.User.LastName;
            BirthDate = voter.BirthDate;
            Address = voter.User.Address;
            ElectoralDistrictId = voter.ElectoralDistrictId;
        }

        public int Id { get; set; }

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        [Display(Name = "Electoral District")]
        public int ElectoralDistrictId { get; set; }

        public IEnumerable<ElectoralDistrict> ElectoralDistricts { get; set; }
    }
}