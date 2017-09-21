using System.Web.Mvc;
using CarShowroom.DAL;
using CarShowroom.ViewModels;
using System.Linq;

namespace CarShowroom.Controllers
{
	public class HomeController : Controller
	{
		private CarShowroomContext db = new CarShowroomContext();

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			IQueryable<PurchaseDateGroup> data = from purchase in db.Purchases
												   group purchase by purchase.TransactionDate into dateGroup
												   select new PurchaseDateGroup()
												   {
													   TransactionDate = dateGroup.Key,
													   PurchaseCount = dateGroup.Count()
												   };
			return View(data.ToList());
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Kontakt";

			return View();
		}
	}
}