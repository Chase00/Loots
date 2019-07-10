using Microsoft.AspNet.Identity;
using MobLoot.Data;
using MobLoot.Models.Loot;
using MobLoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobLoot.WebMVC.Controllers
{
    [Authorize]
    public class LootController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Loot
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LootService(userId);
            var model = service.GetLoot();

            return View(model);
        }
        public ActionResult Create()
        {
            var monsters = _db.Monsters.ToList().Where(t => t.OwnerId == Guid.Parse(User.Identity.GetUserId()));
            ViewBag.MonsterId = new SelectList(monsters, "MonsterId", "MonsterName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LootCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLootService();

            if (service.CreateLoot(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", $"{model.LootName} could not be created.");

            return View(model);
        }

        private LootService CreateLootService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LootService(userId);
            return service;
        }
        public ActionResult Details(int id)
        {
            var svc = CreateLootService();
            var model = svc.GetLootById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var monsters = _db.Monsters.ToList().Where(t => t.OwnerId == Guid.Parse(User.Identity.GetUserId())); //Getting logged in user's list
            ViewBag.MonsterId = new SelectList(monsters, "MonsterId", "MonsterName");

            var service = CreateLootService();
            var detail = service.GetLootById(id);
            var model =
                new LootEdit
                {
                    LootId = detail.LootId,
                    LootName = detail.LootName,
                    LootDesc = detail.LootDesc,
                    MonsterId = detail.MonsterId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LootEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.LootId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLootService();

            if (service.UpdateLoot(model))
            {
                TempData["SaveResult"] = ($"{model.LootName} was updated.");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", ($"{model.LootName} could not be updated."));
            return View(model);
        }
    }
}