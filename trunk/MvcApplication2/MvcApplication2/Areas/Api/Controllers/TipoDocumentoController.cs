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
    public class TipoDocumentoController : Controller
    {
        private Context4 db = new Context4();

        //
        // GET: /Api/TipoDocumento/

        public ActionResult Index()
        {
            return View(db.TipoDocumentoes.ToList());
        }

        //
        // GET: /Api/TipoDocumento/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        //
        // GET: /Api/TipoDocumento/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Api/TipoDocumento/Create

        [HttpPost]
        public ActionResult Create(TipoDocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDocumentoes.Add(tipodocumento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipodocumento);
        }

        //
        // GET: /Api/TipoDocumento/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        //
        // POST: /Api/TipoDocumento/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoDocumento tipodocumento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipodocumento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipodocumento);
        }

        //
        // GET: /Api/TipoDocumento/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            if (tipodocumento == null)
            {
                return HttpNotFound();
            }
            return View(tipodocumento);
        }

        //
        // POST: /Api/TipoDocumento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDocumento tipodocumento = db.TipoDocumentoes.Find(id);
            db.TipoDocumentoes.Remove(tipodocumento);
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