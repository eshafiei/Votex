using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using AutoMapper;
using Votex.Models.Core;
using Votex.Models.Core.Domain;
using Votex.Models.Dto;
using Votex.ViewModels;

namespace Votex.Controllers
{
    public class BallotsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BallotsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Ballots
        public ActionResult Index()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var viewModel = new BallotViewModel
            {
                ElectoralDistricts = _unitOfWork.ElectoralDistricts.GetAll(),
            };

            viewModel.OpenDate = DateTime.Today;
            viewModel.CloseDate = DateTime.Today;

            return View("BallotForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var ballotInDb = _unitOfWork.Ballots.Get(id);

            if (ballotInDb == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BallotViewModel(ballotInDb)
            {
                ElectoralDistricts = _unitOfWork.ElectoralDistricts.GetAll(),
                Elections = _unitOfWork.Elections.GetSelectedElections(ballotInDb.Id),
                Issues = _unitOfWork.Issues.GetSelectedIssues(ballotInDb.Id),
                SelectedElectionIds = _unitOfWork.Ballots.GetElectionsByBallotId(ballotInDb.Id),
                SelectedIssueIds = _unitOfWork.Ballots.GetIssuesByBallotId(ballotInDb.Id)
            };

            return View("BallotForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BallotViewModel ballotViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("BallotForm", ballotViewModel);
            }

            if (ballotViewModel.Id == 0)
            {
                var ballot = new Ballot
                {
                    OpenDate = ballotViewModel.OpenDate,
                    CloseDate = ballotViewModel.CloseDate,
                    ElectoralDistrictId = ballotViewModel.ElectoralDistrictId
                };

                _unitOfWork.Ballots.Add(ballot);
            }
            else
            {
                var ballotInDb = _unitOfWork.Ballots.Get(ballotViewModel.Id);
                ballotInDb.OpenDate = ballotViewModel.OpenDate;
                ballotInDb.CloseDate = ballotViewModel.CloseDate;
                ballotInDb.Approved = ballotViewModel.Approved;
                ballotInDb.ElectoralDistrictId = ballotViewModel.ElectoralDistrictId;
            }

            if (ballotViewModel.SelectedElectionIds != null)
            {
                UpdateBallotElection(ballotViewModel);
            }
            if (ballotViewModel.SelectedIssueIds != null)
            {
                UpdateBallotIssue(ballotViewModel);
            }
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Ballots");
        }

        public ActionResult Delete(int id)
        {
            var ballotInDb = _unitOfWork.Ballots.Get(id);

            if (ballotInDb == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.Ballots.Remove(ballotInDb);
            _unitOfWork.Complete();

            return View("List");
        }

        public ActionResult GetAllData()
        {
            var model = _unitOfWork.Ballots.GetAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetElectionsByFilter(string query = null)
        {
            var elections = _unitOfWork.Elections.GetAll();

            if (!String.IsNullOrWhiteSpace(query))
                elections = elections.Where(m => m.Office.Contains(query));

            return Json(elections, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetIssuesByFilter(string query = null)
        {
            var issues = _unitOfWork.Issues.GetAll();

            if (!String.IsNullOrWhiteSpace(query))
                issues = issues.Where(m => m.Question.Contains(query));

            return Json(issues, JsonRequestBehavior.AllowGet);
        }

        private void UpdateBallotElection(BallotViewModel ballotViewModel)
        {
            _unitOfWork.Ballots.RemoveBallotElectionsByBallotId(ballotViewModel.Id);

            foreach (var electionId in ballotViewModel.SelectedElectionIds)
            {
                var ballotElection = new BallotElection
                {
                    BallotId = ballotViewModel.Id,
                    ElectionId = electionId
                };
                _unitOfWork.BallotElections.Add(ballotElection);
            }
        }

        private void UpdateBallotIssue(BallotViewModel ballotViewModel)
        {
            _unitOfWork.Ballots.RemoveBallotIssuesByBallotId(ballotViewModel.Id);

            foreach (var issueId in ballotViewModel.SelectedIssueIds)
            {
                var ballotIssue = new BallotIssue
                {
                    BallotId = ballotViewModel.Id,
                    IssueId = issueId
                };
                _unitOfWork.BallotIssues.Add(ballotIssue);
            }
        }
    }
}