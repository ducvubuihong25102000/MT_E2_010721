using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sang5_01_07.Models;

namespace Sang5_01_07.Controllers
{
    public class CinemasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cinemas
        public ActionResult Index()
        {
            return View(db.Cinemas.ToList());
        }

        // GET: Cinemas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // GET: Cinemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinemaId,CinemaName,Description")] Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinemas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinemas);
        }

        // GET: Cinemas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // POST: Cinemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaId,CinemaName,Description")] Cinemas cinemas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinemas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinemas);
        }

        // GET: Cinemas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinemas cinemas = db.Cinemas.Find(id);
            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }

        // POST: Cinemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cinemas cinemas = db.Cinemas.Find(id);
            db.Cinemas.Remove(cinemas);
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
