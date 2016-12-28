using System.Web.Mvc;
using Votex.Models;
using Votex.Models.Core;
using Votex.Models.Core.Domain;

namespace Votex.Controllers
{
    [Authorize(Roles = RoleName.ElectionOfficer + "," + RoleName.Administrator)]
    public class ElectoralDistrictsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ElectoralDistrictsController()
        { }

        public ElectoralDistrictsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var model = new ElectoralDistrict();
            return View("ElectoralDistrictForm", model);
        }

        public ActionResult Edit(int id)
        {
            var electoralDistrictInDb = _unitOfWork.ElectoralDistricts.Get(id);

            if (electoralDistrictInDb == null)
            {
                return HttpNotFound();
            }

            return View("ElectoralDistrictForm", electoralDistrictInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ElectoralDistrict electoralDistrict)
        {
            if (!ModelState.IsValid)
            {
                return View("ElectoralDistrictForm", electoralDistrict);
            }

            if (electoralDistrict.Id == 0)
            {
                _unitOfWork.ElectoralDistricts.Add(electoralDistrict);
            }
            else
            {
                var electoralDistrictInDb = _unitOfWork.ElectoralDistricts.Get(electoralDistrict.Id);
                electoralDistrictInDb.Name = electoralDistrict.Name;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "ElectoralDistricts");
        }

        public ActionResult Delete(int id)
        {
            var electoralDistrictInDb = _unitOfWork.ElectoralDistricts.Get(id);

            if (electoralDistrictInDb == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.ElectoralDistricts.Remove(electoralDistrictInDb);
            _unitOfWork.Complete();

            return View("List");
        }

        public ActionResult GetAllData()
        {
            var model = _unitOfWork.ElectoralDistricts.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}