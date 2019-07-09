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
    }
}