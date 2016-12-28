using System.Collections.Generic;
using System.Linq;
using Votex.Model.Base;
using Votex.Model.Entity;
using Votex.Service.Interface;

namespace Votex.Service.Base
{
    public class PoliticalPartyService : EntityService<PoliticalParty>, IPoliticalPartyService
    {
        private readonly IContext _context;

        public PoliticalPartyService(IContext context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<PoliticalParty>();
        }

        public override IEnumerable<PoliticalParty> GetAll()
        {
            return _context.PoliticalParties.ToList();
        }

        public PoliticalParty GetById(int id)
        {
            return Dbset.SingleOrDefault(p => p.Id == id);
        }
    }
}