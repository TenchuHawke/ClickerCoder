using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace clickerCoder.Controllers
{
    public class HomeController : Controller
    {        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //LogedInUser("admin");
            return View();
        }


        public bool LogedInUser(string CurrentUser)
        {
            
                string selectQry = @"select * from Users where username = '{CurrentUser}'" ;
                foreach(var usr in DbConnector.ExecuteQuery(selectQry))
                {
                    ViewBag.UserName = usr["UserName"];
                }
                 
              return true;  
           
        }
    }
}
