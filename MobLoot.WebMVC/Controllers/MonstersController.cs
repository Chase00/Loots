using MobLoot.Models;
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
        public ActionResult Index()
        {
            var model = new MonstersListItem[0];
            return View(model);
        }
    }
}