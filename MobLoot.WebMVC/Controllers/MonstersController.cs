using Microsoft.AspNet.Identity;
using MobLoot.Data;
using MobLoot.Models;
using MobLoot.Models.Monsters;
using MobLoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobLoot.WebMVC.Controllers
{
    [Authorize]
    public class MonstersController : Controller
    {
        // GET: Monsters
        public ActionResult Index() // Show the user their specific monsters
        {
            var userId = Guid.Parse(User.Identity.GetUserId()); // Sets userId to the GUID of the logged in user
            var service = new MonstersService(userId); // Sets service to the user's list of monsters they created
            var model = service.GetMonsters(); // Gets the user's list of monsters
            return View(model); // Returns the user's list of monsters
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MonstersCreate model) // Takes in the user's input
        {
            if (!ModelState.IsValid) return View(model); // If the input is not valid, return what they input (error) & do not send 

            var service = CreateMonstersService();

            if (service.CreateMonster(model))
            {
                TempData["SaveResult"] = $"{model.MonsterName} was successfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Monster could not be created.");

            return View(model);
        }

        private MonstersService CreateMonstersService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId()); // Gets the user's ID when the data is created
            var service = new MonstersService(userId); // Creates the new monster under their userID // 8.02
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMonstersService();
            var model = svc.GetMonsterById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateMonstersService();
            var detail = service.GetMonsterById(id);
            var model =
                new MonstersEdit
                {
                    MonsterId = detail.MonsterId,
                    MonsterName = detail.MonsterName,
                    MonsterDesc = detail.MonsterDesc,
                    MonsterLevel = detail.MonsterLevel
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MonstersEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MonsterId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMonstersService();

            if (service.UpdateMonster(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMonstersService();
            var model = svc.GetMonsterById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTheMonster(int id)
        {
            var service = CreateMonstersService();

            var model = service.GetMonsterById(id);

            service.DeleteMonster(id);

            TempData["SaveResult"] = $"{model.MonsterName} has been deleted";
            return RedirectToAction("Index");
        }
    }
}