using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Practica5.Controllers
{
    public class EVENTOesController : Controller
    {
        private EventosEntities db = new EventosEntities();

        // GET: EVENTOes
        public ActionResult Index()
        {
            return View(db.EVENTO.ToList());
        }

        // GET: EVENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // GET: EVENTOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EVENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,FECHA,HORA")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.EVENTO.Add(eVENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eVENTO);
        }

        // GET: EVENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // POST: EVENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,FECHA,HORA")] EVENTO eVENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eVENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eVENTO);
        }

        // GET: EVENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVENTO eVENTO = db.EVENTO.Find(id);
            if (eVENTO == null)
            {
                return HttpNotFound();
            }
            return View(eVENTO);
        }

        // POST: EVENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVENTO eVENTO = db.EVENTO.Find(id);
            db.EVENTO.Remove(eVENTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
