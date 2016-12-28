using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Votex.Models.Core;
using Votex.ViewModels;

namespace Votex.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfilesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Profiles/Edit
        public ActionResult Edit()
        {
            var userId = User.Identity.GetUserId();
            var voter = _unitOfWork.Voters.SingleOrDefault(v => v.UserId == userId);

            if (voter == null)
            {
                return HttpNotFound();
            }

            var viewModel = new VoterViewModel(voter)
            {
                ElectoralDistricts = _unitOfWork.ElectoralDistricts.GetAll()
            };
            return View(viewModel);
        }

        // POST: Profiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VoterViewModel voter)
        {
            try
            {
                var voterInDb = _unitOfWork.Voters.Get(id);
                voterInDb.User.FirstName = voter.FirstName;
                voterInDb.User.LastName = voter.LastName;
                voterInDb.BirthDate = voter.BirthDate;
                voterInDb.User.Address = voter.Address;
                voterInDb.ElectoralDistrictId = voter.ElectoralDistrictId;
                _unitOfWork.Complete();

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }
    }
}
