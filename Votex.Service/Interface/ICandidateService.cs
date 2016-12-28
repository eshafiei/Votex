using Votex.Model.Entity;

namespace Votex.Service.Interface
{
    public interface ICandidateService : IEntityService<Candidate>
    {
        Candidate GetById(int id);
    }
}
