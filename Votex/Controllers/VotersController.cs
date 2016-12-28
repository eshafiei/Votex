using System.Web.Mvc;
using Votex.Models;
using Votex.Models.Core;
using Votex.ViewModels;

namespace Votex.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    public class VotersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VotersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Voters
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Edit(int id)
        {
            var voterInDb = _unitOfWork.Voters.Get(id);

            if (voterInDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new VoterViewModel(voterInDb)
            {
                ElectoralDistricts = _unitOfWork.ElectoralDistricts.GetAll()
            };

            return View("VoterForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VoterViewModel voter)
        {
            if (!ModelState.IsValid)
            {
                return View("VoterForm", voter);
            }

            var voterInDb = _unitOfWork.Voters.Get(voter.Id);
            voterInDb.User.FirstName = voter.FirstName;
            voterInDb.User.LastName = voter.LastName;
            voterInDb.BirthDate = voter.BirthDate;
            voterInDb.ElectoralDistrictId = voter.ElectoralDistrictId;
            
            _unitOfWork.Complete();
            
            return RedirectToAction("Index", "Voters");
        }

        public ActionResult GetAllData()
        {
            var voters = _unitOfWork.Voters.GetAll();
            return Json(voters, JsonRequestBehavior.AllowGet);
        }
    }
}