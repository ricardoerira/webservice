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
    public class PaisController : Controller
    {
        private Context4 db = new Context4();

       
        // GET: /Api/Pais/
        public List<Pais> ObtenerPaises()
        {
            return db.Paises.ToList();

        }

        [HttpGet]
        public JsonResult Paises()
        {
            return Json(ObtenerPaises(),
                        JsonRequestBehavior.AllowGet);
        }


        public Pais ObtenerPais(int id)
        {

            Pais pais = db.Paises.Find(id);

            return pais;
        }


        public JsonResult Usuario(int? id, Usuario item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                return Json(InsertarUsuario(item));
                case "PUT":
                //  return Json(ActualizarColegios(item));
                case "GET":
                    return Json(ObtenerPais(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);

            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }















        //
        // GET: /Api/Pais/

        public ActionResult Index()
        {
            return View(db.Paises.ToList());
        }

        //
        // GET: /Api/Pais/Details/5

        public ActionResult Details(int id = 0)
        {
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // GET: /Api/Pais/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Api/Pais/Create

        [HttpPost]
        public ActionResult Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Paises.Add(pais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pais);
        }

        //
        // GET: /Api/Pais/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Api/Pais/Edit/5

        [HttpPost]
        public ActionResult Edit(Pais pais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        //
        // GET: /Api/Pais/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Api/Pais/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = db.Paises.Find(id);
            db.Paises.Remove(pais);
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