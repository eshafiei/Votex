using System;
using System.IO;
using System.Web.Mvc;
using Votex.Models.Core;
using Votex.Models.Core.Domain;

namespace Votex.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public IssuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Issues
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var model = new Issue();
            return View("IssueForm", model);
        }

        public ActionResult Edit(int id)
        {
            var issueInDb = _unitOfWork.Issues.Get(id);

            if (issueInDb == null)
            {
                return HttpNotFound();
            }

            return View("IssueForm", issueInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return View("IssueForm", issue);
            }

            if (issue.Id == 0)
            {
                _unitOfWork.Issues.Add(issue);
            }
            else
            {
                var issueInDb = _unitOfWork.Issues.Get(issue.Id);
                issueInDb.Question = issue.Question;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Issues");
        }

        public ActionResult Delete(int id)
        {
            var issueInDb = _unitOfWork.Issues.Get(id);

            if (issueInDb == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.Issues.Remove(issueInDb);
            _unitOfWork.Complete();

            return View("List");
        }

        public ActionResult GetAllData()
        {
            var model = _unitOfWork.Issues.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetIssues(string query = null)
        {
            return Json(_unitOfWork.Issues.GetIssues(query), JsonRequestBehavior.AllowGet);
        }
    }
}