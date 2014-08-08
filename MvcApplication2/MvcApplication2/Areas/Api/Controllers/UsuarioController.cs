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
    public class UsuarioController : Controller
    {
        
        
        private Context4 db = new Context4();

        public bool InsertarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }



        // GET: /Api/Pais/
        public List<Usuario> ObtenerUsuarios()
        {
            return db.Usuarios.ToList();

        }

        [HttpGet]
        public JsonResult Usuarios()
        {
            return Json(ObtenerUsuarios(),
                        JsonRequestBehavior.AllowGet);
        }


        public Usuario ObtenerUsuario(int n)
        {

            Usuario pais = db.Usuarios.Find(id);

            return pais;
        }


        public JsonResult Usuario(int? id, Usuario item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                return Json(Inser(item));
                case "PUT":
                //  return Json(ActualizarColegios(item));
                case "GET":
                    return Json(ObtenerUsuario(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);

            }

            return Json(new { Error = true, Message = "Operación HTTP desconocida" });
        }
























        //
        // GET: /Api/Usuario/

        public ActionResult Index()
        {
            var usuarios = db.Usuarios.Include(u => u.TipoDocumentos).Include(u => u.TipoUsuarios).Include(u => u.Municipios);
            return View(usuarios.ToList());
        }

        //
        // GET: /Api/Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Api/Usuario/Create

        public ActionResult Create()
        {
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentoes, "tipoDocumentoId", "tipo_doc");
            ViewBag.tipoUsuarioId = new SelectList(db.TipoIdentificacions, "tipoUsuarioId", "tusu_nombre");
            ViewBag.municipioId = new SelectList(db.Municipios, "municipioId", "mun_nombre");
            return View();
        }

        //
        // POST: /Api/Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentoes, "tipoDocumentoId", "tipo_doc", usuario.tipoDocumentoId);
            ViewBag.tipoUsuarioId = new SelectList(db.TipoIdentificacions, "tipoUsuarioId", "tusu_nombre", usuario.tipoUsuarioId);
            ViewBag.municipioId = new SelectList(db.Municipios, "municipioId", "mun_nombre", usuario.municipioId);
            return View(usuario);
        }

        //
        // GET: /Api/Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentoes, "tipoDocumentoId", "tipo_doc", usuario.tipoDocumentoId);
            ViewBag.tipoUsuarioId = new SelectList(db.TipoIdentificacions, "tipoUsuarioId", "tusu_nombre", usuario.tipoUsuarioId);
            ViewBag.municipioId = new SelectList(db.Municipios, "municipioId", "mun_nombre", usuario.municipioId);
            return View(usuario);
        }

        //
        // POST: /Api/Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoDocumentoId = new SelectList(db.TipoDocumentoes, "tipoDocumentoId", "tipo_doc", usuario.tipoDocumentoId);
            ViewBag.tipoUsuarioId = new SelectList(db.TipoIdentificacions, "tipoUsuarioId", "tusu_nombre", usuario.tipoUsuarioId);
            ViewBag.municipioId = new SelectList(db.Municipios, "municipioId", "mun_nombre", usuario.municipioId);
            return View(usuario);
        }

        //
        // GET: /Api/Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Api/Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
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