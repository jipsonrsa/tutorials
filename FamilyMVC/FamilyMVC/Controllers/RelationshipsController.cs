using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyMVC.Models;

namespace FamilyMVC.Controllers
{
    public class RelationshipsController : Controller
    {
        private FamilyMVCContext db = new FamilyMVCContext();

        // GET: Relationships
        //[Authorize(Roles ="Admin")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Relationships.ToListAsync());
        }

        // GET: Relationships/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationships relationships = await db.Relationships.FindAsync(id);
            if (relationships == null)
            {
                return HttpNotFound();
            }
            return View(relationships);
        }

        // GET: Relationships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Kind,InCrown")] Relationships relationships)
        {
            if (ModelState.IsValid)
            {
                db.Relationships.Add(relationships);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(relationships);
        }

        // GET: Relationships/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationships relationships = await db.Relationships.FindAsync(id);
            if (relationships == null)
            {
                return HttpNotFound();
            }
            return View(relationships);
        }

        // POST: Relationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Kind,InCrown")] Relationships relationships)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationships).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(relationships);
        }

        // GET: Relationships/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationships relationships = await db.Relationships.FindAsync(id);
            if (relationships == null)
            {
                return HttpNotFound();
            }
            return View(relationships);
        }

        // POST: Relationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Relationships relationships = await db.Relationships.FindAsync(id);
            db.Relationships.Remove(relationships);
            await db.SaveChangesAsync();
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
