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
    public class MunicipioController : Controller
    {
        private Context4 db = new Context4();

        //
        // GET: /Api/Municipio/

        public ActionResult Index()
        {
            var municipios = db.Municipios.Include(m => m.Departamentos);
            return View(municipios.ToList());
        }

        //
        // GET: /Api/Municipio/Details/5

        public ActionResult Details(int id = 0)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        //
        // GET: /Api/Municipio/Create

        public ActionResult Create()
        {
            ViewBag.departamentoId = new SelectList(db.Departamentoes, "departamentoId", "dep_nombre");
            return View();
        }

        //
        // POST: /Api/Municipio/Create

        [HttpPost]
        public ActionResult Create(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipios.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.departamentoId = new SelectList(db.Departamentoes, "departamentoId", "dep_nombre", municipio.departamentoId);
            return View(municipio);
        }

        //
        // GET: /Api/Municipio/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.departamentoId = new SelectList(db.Departamentoes, "departamentoId", "dep_nombre", municipio.departamentoId);
            return View(municipio);
        }

        //
        // POST: /Api/Municipio/Edit/5

        [HttpPost]
        public ActionResult Edit(Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.departamentoId = new SelectList(db.Departamentoes, "departamentoId", "dep_nombre", municipio.departamentoId);
            return View(municipio);
        }

        //
        // GET: /Api/Municipio/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Municipio municipio = db.Municipios.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        //
        // POST: /Api/Municipio/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipio municipio = db.Municipios.Find(id);
            db.Municipios.Remove(municipio);
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