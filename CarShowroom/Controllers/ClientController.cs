using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CarShowroom.DAL;
using CarShowroom.Models;
using PagedList;

namespace CarShowroom.Controllers
{
    public class ClientController : Controller
    {
        private CarShowroomContext db = new CarShowroomContext();

        // GET: Client
		public ViewResult Index(string sort, string filter, string search, int? page)
		{
			ViewBag.CurrentSort = sort;

			if(search != null)
			{
				page = 1;
			}
			else
			{
				search = filter;
			}

			ViewBag.CurrentFilter = search;

			var clients = from c in db.Clients
					   select c;

			if (!string.IsNullOrEmpty(search))
			{
				clients = clients.Where(s => s.LastName.Contains(search)
									   || s.FirstName.Contains(search));
			}

			switch (sort)
			{
				case "firstname":
					clients = clients.OrderBy(c => c.FirstName);
					break;
				case "lastname":
					clients = clients.OrderBy(c => c.LastName);
					break;
				case "cnum":
					clients = clients.OrderBy(c => c.Pesel);
					break;
				case "city":
					clients = clients.OrderBy(c => c.City);
					break;
				default:
					clients = clients.OrderBy(c => c.ClientId);
					break;
			}

			int pageSize = 3;
			int pageNumber = (page ?? 1);
			return View(clients.ToPagedList(pageNumber, pageSize));
		}

		// GET: Client/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,LastName,FirstName,Pesel,City,Street,StreetNumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,LastName,FirstName,Pesel,City,Street,StreetNumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
