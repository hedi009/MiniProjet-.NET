using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using miniProjet.Models;
using miniProjet.Repositories;

namespace miniProjet.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class EmployeController : Controller
    {
        readonly IEmployeRepository employerepository;
        readonly IEntrepriseRepository entrepriserepository;
        public EmployeController(IEmployeRepository employerepository, IEntrepriseRepository entrepriserepository)
        {
            this.employerepository = employerepository;
            this.entrepriserepository = entrepriserepository;
        }
        [AllowAnonymous]

        // GET: StudentController

        public ActionResult Index()
        {
            ViewBag.EntrepriseID = new SelectList(entrepriserepository.GetAll(), "EntrepriseID", "EntrepriseName");
            return View(employerepository.GetAll());
        }
        public ActionResult Search(string name, int? entrepriseid)
        {
            var result = employerepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = employerepository.FindByName(name);
            else
            if (entrepriseid != null)
                result = employerepository.GetEmployesByEntrepriseID(entrepriseid);
            ViewBag.EntrepriseID = new SelectList(entrepriserepository.GetAll(), "EntrepriseID", "EntrepriseName");
            return View("Index", result);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(employerepository.GetById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.EntrepriseID = new SelectList(entrepriserepository.GetAll(), "EntrepriseID", "EntrepriseName");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employe s)
        {
            try
            {
                ViewBag.EntrepriseID = new SelectList(entrepriserepository.GetAll(), "EntrepriseID", "EntrepriseName", s.EntrepriseID);
                employerepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.EntrepriseID = new SelectList(entrepriserepository.GetAll(), "EntrepriseID", "EntrepriseName");
            return View(employerepository.GetById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employe s)
        {
            try
            {
                ViewBag.EntrepriseID = new SelectList(entrepriserepository.GetAll(), "EntrepriseID", "EntrepriseName");
                employerepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(employerepository.GetById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employe s)
        {
            try
            {
                employerepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
