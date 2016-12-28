using System.Web.Mvc;
using Votex.Models;
using Votex.Models.Core;
using Votex.Models.Core.Domain;
using Votex.ViewModels;

namespace Votex.Controllers
{
    [Authorize(Roles = RoleName.ElectionOfficer + "," + RoleName.Administrator)]
    public class PoliticalPartiesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PoliticalPartiesController()
        { }

        public PoliticalPartiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var viewModel = new PoliticalPartyViewModel();
            return View("PoliticalPartyForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var model = _unitOfWork.PoliticalParties.Get(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PoliticalPartyViewModel(model);

            return View("PoliticalPartyForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PoliticalParty politicalParty)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PoliticalPartyViewModel(politicalParty);
                return View("PoliticalPartyForm", viewModel);
            }

            if (politicalParty.Id > 0)
            {
                var politicalPartyInDb = _unitOfWork.PoliticalParties.Get(politicalParty.Id);
                politicalPartyInDb.Name = politicalParty.Name;
            }
            else
            {
                _unitOfWork.PoliticalParties.Add(politicalParty);
            }

            _unitOfWork.Complete();
            return RedirectToAction("Index", "PoliticalParties");
        }

        public ActionResult Delete(int id)
        {
            var politicalPartyInDb = _unitOfWork.PoliticalParties.Get(id);

            if (politicalPartyInDb == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.PoliticalParties.Remove(politicalPartyInDb);
            _unitOfWork.Complete();

            return View("List");
        }

        public ActionResult GetAllData()
        {
            var model = _unitOfWork.PoliticalParties.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}