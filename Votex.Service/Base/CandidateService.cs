using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Votex.Model.Base;
using Votex.Model.Entity;
using Votex.Service.Interface;

namespace Votex.Service.Base
{
    public class CandidateService : EntityService<Candidate>, ICandidateService
    {
        private readonly IContext _context;

        public CandidateService(IContext context) : base(context)
        {
            _context = context;
            Dbset = _context.Set<Candidate>();
        }

        public override IEnumerable<Candidate> GetAll()
        {
            return _context.Candidates.Include(p => p.PoliticalParty).ToList();
        }

        public Candidate GetById(int id)
        {
            return Dbset.SingleOrDefault(p => p.Id == id);
        }
    }
}
