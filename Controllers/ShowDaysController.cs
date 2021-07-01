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
    public class ShowDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShowDays
        public ActionResult Index()
        {
            return View(db.ShowDays.ToList());
        }

        // GET: ShowDays/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDays showDays = db.ShowDays.Find(id);
            if (showDays == null)
            {
                return HttpNotFound();
            }
            return View(showDays);
        }

        // GET: ShowDays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowDayID,Day")] ShowDays showDays)
        {
            if (ModelState.IsValid)
            {
                db.ShowDays.Add(showDays);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(showDays);
        }

        // GET: ShowDays/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDays showDays = db.ShowDays.Find(id);
            if (showDays == null)
            {
                return HttpNotFound();
            }
            return View(showDays);
        }

        // POST: ShowDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowDayID,Day")] ShowDays showDays)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showDays).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showDays);
        }

        // GET: ShowDays/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowDays showDays = db.ShowDays.Find(id);
            if (showDays == null)
            {
                return HttpNotFound();
            }
            return View(showDays);
        }

        // POST: ShowDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ShowDays showDays = db.ShowDays.Find(id);
            db.ShowDays.Remove(showDays);
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
