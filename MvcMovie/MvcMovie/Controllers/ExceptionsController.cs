using System;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class ExceptionsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Page for testing exepction handling.";

            return View();
        }

        [HttpPost]
        public ActionResult NullReferenceException()
        {
            throw new NullReferenceException();
        }

        [HttpPost]
        public ActionResult InvalidOperationException()
        {
            throw new InvalidOperationException();
        }

        [HttpPost]
        public ActionResult DivideByZeroException()
        {
            throw new DivideByZeroException();
        }
    }
}
