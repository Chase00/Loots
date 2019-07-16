using Microsoft.AspNet.Identity;
using MobLoot.Data;
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
            var monsters = _db.Monsters.ToList().Where(t => t.OwnerId == Guid.Parse(User.Identity.GetUserId()));
            ViewBag.MonsterId = new SelectList(monsters, "MonsterId", "MonsterName");
            return View();
        }

    }
}