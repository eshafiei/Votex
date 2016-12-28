using System.ComponentModel.DataAnnotations;
using Votex.Models.Core.Domain;

namespace Votex.ViewModels
{
    public class PoliticalPartyViewModel
    {
        public PoliticalPartyViewModel()
        {
            Id = 0;
        }

        public PoliticalPartyViewModel(PoliticalParty politicalParty)
        {
            Name = politicalParty.Name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}