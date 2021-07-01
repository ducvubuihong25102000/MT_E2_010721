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
    public class ShowsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Shows
        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Cinemas).Include(s => s.Movies).Include(s => s.ShowDays).Include(s => s.ShowTimes);
            return View(shows.ToList());
        }

        // GET: Shows/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            return View(shows);
        }

        // GET: Shows/Create
        public ActionResult Create()
        {
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "CinemaName");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.ShowDayId = new SelectList(db.ShowDays, "ShowDayID", "ShowDayID");
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID");
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowId,CinemaId,ShowDayId,MovieId,ShowTimeId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                db.Shows.Add(shows);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "CinemaName", shows.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", shows.MovieId);
            ViewBag.ShowDayId = new SelectList(db.ShowDays, "ShowDayID", "ShowDayID", shows.ShowDayId);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID", shows.ShowTimeId);
            return View(shows);
        }

        // GET: Shows/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "CinemaName", shows.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", shows.MovieId);
            ViewBag.ShowDayId = new SelectList(db.ShowDays, "ShowDayID", "ShowDayID", shows.ShowDayId);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID", shows.ShowTimeId);
            return View(shows);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShowId,CinemaId,ShowDayId,MovieId,ShowTimeId")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shows).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaId = new SelectList(db.Cinemas, "CinemaId", "CinemaName", shows.CinemaId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", shows.MovieId);
            ViewBag.ShowDayId = new SelectList(db.ShowDays, "ShowDayID", "ShowDayID", shows.ShowDayId);
            ViewBag.ShowTimeId = new SelectList(db.ShowTimes, "ShowTimeID", "ShowTimeID", shows.ShowTimeId);
            return View(shows);
        }

        // GET: Shows/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shows shows = db.Shows.Find(id);
            if (shows == null)
            {
                return HttpNotFound();
            }
            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Shows shows = db.Shows.Find(id);
            db.Shows.Remove(shows);
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
