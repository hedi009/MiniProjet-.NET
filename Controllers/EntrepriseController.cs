using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using miniProjet.Models;
using miniProjet.Repositories;

namespace miniProjet.Controllers
{
    [Authorize(Roles = "Admin,Manager")]

    public class EntrepriseController : Controller
    {
        
       
            readonly IEntrepriseRepository entrepriserepository;
            public EntrepriseController(IEntrepriseRepository entrepriserepository)
            {
                this.entrepriserepository = entrepriserepository;
            }

        [AllowAnonymous]

        // GET: Entreprise Controller
        public ActionResult Index()
            {
                return View(entrepriserepository.GetAll());
            }

            // GET: SchoolController/Details/5
            public ActionResult Details(int id)
            {
                var school = entrepriserepository.GetById(id);
                return View(school);
            }

            // GET: SchoolController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: SchoolController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Entreprise s)
            {
                try
                {
                entrepriserepository.Add(s);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: SchoolController/Edit/5
            public ActionResult Edit(int id)
            {
                var entreprise = entrepriserepository.GetById(id);
                return View(entreprise);
            }

            // POST: SchoolController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Entreprise s)
            {
                try
                {
                entrepriserepository.Edit(s);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            // GET: SchoolController/Delete/5
            public ActionResult Delete(int id)
            {
                var entreprise = entrepriserepository.GetById(id);
                return View(entreprise);
            }

            // POST: SchoolController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(Entreprise s)
            {
                try
                {

                entrepriserepository.Delete(s);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }
    }

