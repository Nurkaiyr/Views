using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViewsLesson.Models;

namespace ViewsLesson.Controllers
{
    public class PlayersController : Controller
    {
        private SportContext db = new SportContext();

        // GET: Players
        public async Task<ActionResult> Index()
        {
            return View(await db.Players.ToListAsync());
        }

        // GET: Players/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Number")] Player player)
        {
            if (ModelState.IsValid)
            {
                player.Id = Guid.NewGuid();
                db.Players.Add(player);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Number")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = await db.Players.FindAsync(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Player player = await db.Players.FindAsync(id);
            db.Players.Remove(player);
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
