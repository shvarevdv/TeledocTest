using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TeledocTestProject.Models;

namespace TeledocTestProject.Controllers
{
    public class HomeController : Controller
    {        
        private DataBaseContext dataBase;
        public HomeController(DataBaseContext dataBase)
        {
            this.dataBase = dataBase;           
        }

        public async Task<IActionResult> Index()
        {

            return View(await dataBase.Founders.Include("Client").ToArrayAsync());
        }
        public RedirectToRouteResult RedirectToIndividualEntrepreneurs()
        {

            return RedirectToRoute(new { controller = "IndividualEntrepreneurs", action = "Index" });
        }

        public RedirectToRouteResult RedirectToEntityClients()
        {

            return RedirectToRoute(new { controller = "EntityClients", action = "Index" });
        }

        public RedirectToRouteResult RedirectToFounders()
        {

            return RedirectToRoute(new { controller = "Founders", action = "Index" });
        }
    }
}
