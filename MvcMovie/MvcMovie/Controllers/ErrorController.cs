using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        // Default fallback
        public ActionResult Index()
        {
            return HttpStatus(500);
        }

        // One endpoint to handle ANY HTTP error code:
        // /Error/HttpStatus?code=404
        // /Error/HttpStatus?code=403
        // /Error/HttpStatus?code=418  (yes, it will still work)
        public ActionResult HttpStatus(int? code)
        {
            var statusCode = code ?? 500;

            // Ensure the response keeps the intended code
            Response.StatusCode = statusCode;

            // Prevent IIS from replacing your MVC page with its own
            Response.TrySkipIisCustomErrors = true;

            // Friendly title/message (no technical details)
            var (title, message) = GetFriendlyMessage(statusCode);

            ViewBag.StatusCode = statusCode;
            ViewBag.Title = title;
            ViewBag.Message = message;

            // Use ONE view for all statuses
            return View("HttpStatus");
        }

        private static (string Title, string Message) GetFriendlyMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return ("Bad request (400)", "We couldn’t process your request. Please check your input and try again.");

                case 401:
                    return ("Unauthorized (401)", "You need to sign in to access this page.");

                case 403:
                    return ("Forbidden (403)", "You don’t have access to this page.");

                case 404:
                    return ("Not found (404)", "The page you’re looking for doesn’t exist or was moved.");

                case 405:
                    return ("Method not allowed (405)", "This action isn’t allowed for this request.");

                case 408:
                    return ("Request timeout (408)", "The request took too long. Please try again.");

                case 409:
                    return ("Conflict (409)", "There was a conflict while processing your request. Please try again.");

                case 410:
                    return ("Gone (410)", "This resource is no longer available.");

                case 413:
                    return ("Payload too large (413)", "The uploaded file is too large.");

                case 414:
                    return ("URI too long (414)", "The request URL is too long.");

                case 415:
                    return ("Unsupported media type (415)", "This content type is not supported.");

                case 429:
                    return ("Too many requests (429)", "You’re doing that too often. Please wait and try again.");

                case 500:
                    return ("Internal server error (500)", "Something went wrong on our side. Please try again.");

                case 501:
                    return ("Not implemented (501)", "This feature isn’t available.");

                case 502:
                    return ("Bad gateway (502)", "A downstream service returned an invalid response.");

                case 503:
                    return ("Service unavailable (503)", "The service is temporarily unavailable. Please try again later.");

                case 504:
                    return ("Gateway timeout (504)", "A downstream service took too long to respond.");

                case 505:
                    return ("HTTP version not supported (505)", "The HTTP protocol version used in this request is not supported by the server.");

                // Catch-all: any other status code
                default:
   
                    if (statusCode >= 400 && statusCode < 500)
                        return ($"Request error ({statusCode})", "There was a problem with your request.");

                    if (statusCode >= 500 && statusCode < 600)
                        return ($"Server error ({statusCode})", "An error occurred. Please try again later.");

                    return ("Non-standard unexpected error (error code unknown)", "An error occurred.");
            }
        }
    }
}
