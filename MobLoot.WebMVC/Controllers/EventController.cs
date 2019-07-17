using Microsoft.AspNet.Identity;
using MobLoot.Data;
using MobLoot.Models.Event;
using MobLoot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobLoot.WebMVC.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Event
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var monsters = _db.Monsters.Where(t => t.OwnerId == userId).ToList();
            ViewBag.MonsterId = new SelectList(monsters, "MonsterId", "MonsterName");
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult GetSelectedMonsters(EventModel model) // Taking in selected monster
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var monsters = _db.Monsters.Where(t => t.OwnerId == userId).ToList();
            ViewBag.MonsterId = new SelectList(monsters, "MonsterId", "MonsterName");

            if (!ModelState.IsValid) // If what they input is valid (selecting a monster)
            {
                return View(model); // Error
            }
            var service = GetEventService(); // Something something validate user

            EventModel newModel = service.RandomLoot(model);

            if (newModel != null)
            {
                TempData["SaveResult"] = $"You received {newModel.LootName}!";
            }
            return View();
        }

        public EventService GetEventService() // Get User by Guid
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}