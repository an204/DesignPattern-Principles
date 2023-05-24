using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository_UnitOfWork.Etities;
using System.Net;
using System.Text;

namespace Repository_UnitOfWork.Controllers
{
    public class SwaggerLogginController : Controller
    {
        // GET: SwaggerLogginController
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(SwaggerUserLoggin user)
        {
            //Your other Code will go here
            
            if(user.username =="admin" && user.password =="123") {
                HttpContext.Session.SetString("SwaggerAuthenticated", "true");
                return Redirect("/swagger/index.html");
            }
            else
            {
                return RedirectToAction("Login");
            }
            
           
        }


    }
}
