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
        private readonly ILogger<HomeController> _logger;

        private DataBaseContext dataBase;
        public HomeController(DataBaseContext dataBase)
        {
            this.dataBase = dataBase;
            if (dataBase.Founders.Count() == 0)
            {
                //Founder ivanFounder = new Founder { FirstName = "Ivan", SecondName = "Ivanovich", LastName = "Ivanov" };
                //ivanFounder.SetCreateDate();
                //ivanFounder.SetUpdateDate();
                //Founder petrFounder = new Founder { FirstName = "Petr", SecondName = "Petrovich", LastName = "Petrov" };
                //petrFounder.SetCreateDate();
                //petrFounder.SetUpdateDate();
                //Founder viktorFounder = new Founder { FirstName = "Viktor", SecondName = "Viktorovich", LastName = "Petrov" };
                //viktorFounder.SetCreateDate();
                //viktorFounder.SetUpdateDate();

                //IndividualEntrepreneur ivanPrivate = new IndividualEntrepreneur { Name = "John" };
                //ivanPrivate.SetCreateDate();
                //ivanPrivate.SetUpdateDate();
                //IndividualEntrepreneur peterPrivate = new IndividualEntrepreneur { Name = "Peter" };
                //peterPrivate.SetCreateDate();
                //ivanPrivate.SetUpdateDate();
                //IndividualEntrepreneur viktorPrivate = new IndividualEntrepreneur { Name = "Viktor" };
                //peterPrivate.SetCreateDate();
                //viktorPrivate.SetUpdateDate();

                //EntityClient ivanEntity = new EntityClient { Name = "John" };
                //ivanEntity.SetCreateDate();
                //ivanEntity.SetUpdateDate();
                //ivanEntity.Founders.Append(ivanFounder);
                //ivanEntity.Founders.Append(petrFounder);
                //EntityClient peterEntity = new EntityClient { Name = "Peter" };
                //peterEntity.SetCreateDate();
                //peterEntity.SetUpdateDate();
                //peterEntity.Founders.Append(viktorFounder);
                //peterEntity.Founders.Append(petrFounder);
                //EntityClient viktorEntity = new EntityClient { Name = "Viktor" };
                //viktorEntity.SetCreateDate();
                //viktorEntity.SetUpdateDate();
                //viktorEntity.Founders.Append(ivanFounder);

                //dataBase.Founders.AddRange(ivanFounder, petrFounder, viktorFounder);
                //dataBase.IndividualEntrepreneurs.AddRange(ivanPrivate, peterPrivate, viktorPrivate);
                //dataBase.EntityClients.AddRange(ivanEntity, peterEntity, viktorEntity);
                //dataBase.SaveChanges();
            }
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
