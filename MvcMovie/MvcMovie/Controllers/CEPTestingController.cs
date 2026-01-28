using System;
using System.Net;
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
        public ActionResult HttpStatus500()
        {
            return new HttpStatusCodeResult(500, "Forced HttpStatus 500");
        }

        #endregion Force specific HttpStatus


        #region Force specific HttpException

        [HttpPost]
        public ActionResult HttpException500()
        {
            throw new HttpException((int)HttpStatusCode.InternalServerError, "Forced HttpException 500");
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
