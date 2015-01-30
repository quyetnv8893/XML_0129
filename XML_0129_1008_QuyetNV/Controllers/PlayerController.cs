using PlayerManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayerManagement.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        private IPlayerRepository _repository;
       // private SelectList typeList = new SelectList(new[]{"Meeting","Requirements","Development","Testing","Documentation"});

        public PlayerController(): this(new PlayerRepository())
        {
        }

        public PlayerController(IPlayerRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            return View(_repository.GetPlayers());
        }


        public ActionResult Details(String id)
        {
            Player player = _repository.GetPlayerByID(id);
            if (player == null)
                return RedirectToAction("Index");

            return View(player);
        }


        /**public ActionResult Create()
        {
            ViewBag.TypeList = typeList;
            return View();
        }**/


        [HttpPost]
        public ActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertPlayer(player);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    //error msg for failed insert in XML file
                    ModelState.AddModelError("", "Error creating record. " + ex.Message);
                }
            }

            return View(player);
        }


        /**public ActionResult Edit(String id)
        {
            Player player = _repository.GetPlayerByID(id);
            if (player == null)
                return RedirectToAction("Index");

            ViewBag.TypeList = typeList;
            return View(player);
        }**/


        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.EditPlayer(player);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //error msg for failed edit in XML file
                    ModelState.AddModelError("", "Error editing record. " + ex.Message);
                }
            }

            return View(player);
        }


        public ActionResult Delete(String id)
        {
            Player player = _repository.GetPlayerByID(id);
            if (player == null)
                return RedirectToAction("Index");
            return View(player);
        }


        [HttpPost]
        public ActionResult Delete(String id, FormCollection collection)
        {
            try
            {
                _repository.DeletePlayer(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                //error msg for failed delete in XML file
                ViewBag.ErrorMsg = "Error deleting record. " + ex.Message;
                return View(_repository.GetPlayerByID(id));
            }
        }
    }
}