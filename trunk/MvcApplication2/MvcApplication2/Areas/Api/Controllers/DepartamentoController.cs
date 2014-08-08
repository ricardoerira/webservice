using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Areas.Api.Models;

namespace MvcApplication2.Areas.Api.Controllers
{
    public class DepartamentoController : Controller
    {
        private Context4 db = new Context4();








        // GET: /Api/Pais/
        public List<Departamento> ObtenerDepartamentos()
        {
            return db.Departamentoes.ToList();

        }

        [HttpGet]
        public JsonResult Paises()
        {
            return Json(ObtenerDepartamentos(),
                        JsonRequestBehavior.AllowGet);
        }


        public Departamento ObtenerDpto(int id)
        {

            Departamento dpto = db.Departamentoes.Find(id);

            return dpto;
        }


        public JsonResult Pais(int? id, Pais item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                //return Json(InsertarColegios(item));
                case "PUT":
                //  return Json(ActualizarColegios(item));
                case "GET":
                    return Json(ObtenerDpto(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);

            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }










        //
        // GET: /Api/Departamento/

        public ActionResult Index()
        {
            var departamentoes = db.Departamentoes.Include(d => d.Paises);
            return View(departamentoes.ToList());
        }

        //
        // GET: /Api/Departamento/Details/5

        public ActionResult Details(int id = 0)
        {
            Departamento departamento = db.Departamentoes.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        //
        // GET: /Api/Departamento/Create

        public ActionResult Create()
        {
            ViewBag.paisId = new SelectList(db.Paises, "paisId", "pai_nombre");
            return View();
        }

        //
        // POST: /Api/Departamento/Create

        [HttpPost]
        public ActionResult Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Departamentoes.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.paisId = new SelectList(db.Paises, "paisId", "pai_nombre", departamento.paisId);
            return View(departamento);
        }

        //
        // GET: /Api/Departamento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Departamento departamento = db.Departamentoes.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.paisId = new SelectList(db.Paises, "paisId", "pai_nombre", departamento.paisId);
            return View(departamento);
        }

        //
        // POST: /Api/Departamento/Edit/5

        [HttpPost]
        public ActionResult Edit(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.paisId = new SelectList(db.Paises, "paisId", "pai_nombre", departamento.paisId);
            return View(departamento);
        }

        //
        // GET: /Api/Departamento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Departamento departamento = db.Departamentoes.Find(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        //
        // POST: /Api/Departamento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento departamento = db.Departamentoes.Find(id);
            db.Departamentoes.Remove(departamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}