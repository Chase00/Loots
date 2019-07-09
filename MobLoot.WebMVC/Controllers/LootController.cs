using MobLoot.Models.Loot;
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
        // GET: Loot
        public ActionResult Index()
        {
            var model = new LootListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LootCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}