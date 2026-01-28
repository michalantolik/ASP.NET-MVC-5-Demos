using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    [HandleError]
    public class ErrorController : Controller
    {
        /// <summary>
        /// Show Fallback CEP.
        /// </summary>
        public ActionResult FallbackError()
        {
            return View();
        }

        /// <summary>
        /// Show CEP for "InternalServerError, 500".
        /// </summary>
        public ActionResult InternalServerError()
        {
            return View();
        }
    }
}
