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
    public class ShowTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ShowTimes
        public ActionResult Index()
        {
            return View(db.ShowTimes.ToList());
        }

        // GET: ShowTimes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTimes showTimes = db.ShowTimes.Find(id);
            if (showTimes == null)
            {
                return HttpNotFound();
            }
            return View(showTimes);
        }

        // GET: ShowTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowTimeID,Time")] ShowTimes showTimes)
        {
            if (ModelState.IsValid)
            {
                db.ShowTimes.Add(showTimes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(showTimes);
        }

        // GET: ShowTimes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTimes showTimes = db.ShowTimes.Find(id);
            if (showTimes == null)
            {
                return HttpNotFound();
            }
            return View(showTimes);
        }

        // POST: ShowTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowTimeID,Time")] ShowTimes showTimes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showTimes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showTimes);
        }

        // GET: ShowTimes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShowTimes showTimes = db.ShowTimes.Find(id);
            if (showTimes == null)
            {
                return HttpNotFound();
            }
            return View(showTimes);
        }

        // POST: ShowTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ShowTimes showTimes = db.ShowTimes.Find(id);
            db.ShowTimes.Remove(showTimes);
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
