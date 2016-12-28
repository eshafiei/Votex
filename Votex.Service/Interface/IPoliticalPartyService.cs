using Votex.Models.Entity;

namespace Votex.Service.Interface
{
    public interface IPoliticalPartyService : IEntityService<PoliticalParty>
    {
        PoliticalParty GetById(int id);
    }
}
