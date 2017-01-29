using System.Web.Mvc;
using Budget.Planning.Logic;
using Budget.Planning.Web.Models;

namespace Budget.Planning.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISync _sync = null;

        public HomeController(ISync sync)
        {
            _sync = sync;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sync()
        {
            var sync = _sync.SyncTransactions();

            return Json(sync);
        }
    }
}