using PlayerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlayerManagement.Models;

namespace PlayerManagement.Controllers
{
    public class MatchController2 : Controller
    {
        // GET: Match
        private IMatchRepository _repository;
        public MatchController2(): this(new MatchRepository())
        {
        }

        public MatchController2(IMatchRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            return View(_repository.GetMatches());
        }


        public ActionResult Details(String id)
        {
            Match match = _repository.GetMatchByID(id);
            if (match == null)
                return RedirectToAction("Index");
            return View(match);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Match match)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertMatch(match);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(match);
        }

        public ActionResult Edit(String id)
        {
            Match match = _repository.GetMatchByID(id);
            if (match == null)
                return RedirectToAction("Index");
            return View(match);
        }
       
        [HttpPost]
        public ActionResult Edit(Match match)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditMatch(match);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(match);
        }       

        [HttpPost]
        public ActionResult Delete(Match match)
        {
            try
            {
                _repository.DeleteMatch(match.id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetMatchByID(match.id));
            }
        }
    }
}