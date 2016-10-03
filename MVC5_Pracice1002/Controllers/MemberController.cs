using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_Pracice1002.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}