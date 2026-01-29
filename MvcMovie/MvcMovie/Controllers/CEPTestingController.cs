using System;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class CEPTestingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region Force specific HttpStatus

        [HttpPost]
        public ActionResult HttpStatus(int? code)
        {
            var statusCode = code ?? 500;

            return new HttpStatusCodeResult(statusCode, $"Forced HttpStatus {statusCode}");
        }

        #endregion Force specific HttpStatus


        #region Force specific HttpException

        [HttpPost]
        public ActionResult HttpException(int? code)
        {
            var statusCode = code ?? 500;

            throw new HttpException(statusCode, $"Forced HttpException {statusCode}");
        }

        #endregion Force specific HttpException


        #region Force other C# excepction

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

        #endregion Force other C# excepction
    }
}
