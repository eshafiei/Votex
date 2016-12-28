using System.Web.Mvc;
using Votex.Models.Core;
using Votex.Models.Core.Domain;

namespace Votex.Controllers
{
    public class ElectionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ElectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Elections
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var model = new Election();
            return View("ElectionForm", model);
        }

        public ActionResult Edit(int id)
        {
            var electionInDb = _unitOfWork.Elections.Get(id);

            if (electionInDb == null)
            {
                return HttpNotFound();
            }

            return View("ElectionForm", electionInDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Election election)
        {
            if (!ModelState.IsValid)
            {
                return View("ElectionForm", election);
            }

            if (election.Id == 0)
            {
                _unitOfWork.Elections.Add(election);
            }
            else
            {
                var electionInDb = _unitOfWork.Elections.Get(election.Id);
                electionInDb.Office = election.Office;
                electionInDb.IsPartisan = election.IsPartisan;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Elections");
        }

        public ActionResult Delete(int id)
        {
            var electionInDb = _unitOfWork.Elections.Get(id);

            if (electionInDb == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.Elections.Remove(electionInDb);
            _unitOfWork.Complete();

            return View("List");
        }

        public ActionResult GetAllData()
        {
            var model = _unitOfWork.Elections.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetElections(string query = null)
        {
           return  Json(_unitOfWork.Elections.GetElections(query), JsonRequestBehavior.AllowGet);
        }
    }
}