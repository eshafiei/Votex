using System.Web.Mvc;
using Votex.Models;
using Votex.Models.Core;
using Votex.Models.Core.Domain;
using Votex.ViewModels;

namespace Votex.Controllers
{
    [Authorize(Roles = RoleName.ElectionOfficer + "," + RoleName.Administrator)]
    public class CandidatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CandidatesController()
        { }

        public CandidatesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Candidates
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var politicalParties = _unitOfWork.PoliticalParties.GetAll();

            var viewModel = new CandidateViewModel()
            {
                PoliticalParties = politicalParties
            };

            return View("CandidateForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var candidateInDb = _unitOfWork.Candidates.Get(id);

            if (candidateInDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CandidateViewModel(candidateInDb)
            {
                PoliticalParties = _unitOfWork.PoliticalParties.GetAll()
            };

            return View("CandidateForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CandidateViewModel(candidate)
                {
                    PoliticalParties = _unitOfWork.PoliticalParties.GetAll()
                };

                return View("CandidateForm", viewModel);
            }

            if (candidate.Id == 0)
            {
                _unitOfWork.Candidates.Add(candidate);
            }
            else
            {
                var candidateInDb = _unitOfWork.Candidates.Get(candidate.Id);
                candidateInDb.FirstName = candidate.FirstName;
                candidateInDb.MiddleName = candidate.MiddleName;
                candidateInDb.LastName = candidate.LastName;
                candidateInDb.PoliticalPartyId = candidate.PoliticalPartyId;
            }
            
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Candidates");
        }

        public ActionResult Delete(int id)
        {
            var entity = _unitOfWork.Candidates.Get(id);
            _unitOfWork.Candidates.Remove(entity);
            _unitOfWork.Complete();
            return View("List");
        }

        public ActionResult GetAllData()
        {
            var model = _unitOfWork.Candidates.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}