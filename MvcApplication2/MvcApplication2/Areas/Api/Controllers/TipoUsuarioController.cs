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
    public class TipoUsuarioController : Controller
    {
        private Context4 db = new Context4();

        //
        // GET: /Api/TipoUsuario/

        public ActionResult Index()
        {
            return View(db.TipoIdentificacions.ToList());
        }

        //
        // GET: /Api/TipoUsuario/Details/5

        public ActionResult Details(int id = 0)
        {
            TipoUsuario tipousuario = db.TipoIdentificacions.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        //
        // GET: /Api/TipoUsuario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Api/TipoUsuario/Create

        [HttpPost]
        public ActionResult Create(TipoUsuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.TipoIdentificacions.Add(tipousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipousuario);
        }

        //
        // GET: /Api/TipoUsuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoUsuario tipousuario = db.TipoIdentificacions.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        //
        // POST: /Api/TipoUsuario/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoUsuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipousuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipousuario);
        }

        //
        // GET: /Api/TipoUsuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoUsuario tipousuario = db.TipoIdentificacions.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        //
        // POST: /Api/TipoUsuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoUsuario tipousuario = db.TipoIdentificacions.Find(id);
            db.TipoIdentificacions.Remove(tipousuario);
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