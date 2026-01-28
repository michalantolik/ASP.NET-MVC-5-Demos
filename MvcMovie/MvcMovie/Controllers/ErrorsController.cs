using System;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class ErrorsController : Controller
    {
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
