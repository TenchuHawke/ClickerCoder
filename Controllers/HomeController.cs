using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clickerCoder.Controllers
{
    public class HomeController : Controller
    {        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult index()
        {
            int? Number = HttpContext.Session.GetInt32("Number");
            if (Number == null)
            {
                Number = 0;
            }
            Number += 1;

            ViewBag.RunNumber = Number;
            HttpContext.Session.SetInt32("Number", (int)Number);
            return View();
        }


        [HttpGet]
        [Route("clear")]
        public IActionResult clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    
    public bool LogedInUser(string CurrentUser)
    {

        string selectQry = @"select * from Users where username = '{CurrentUser}'";
        foreach (var usr in DbConnector.ExecuteQuery(selectQry))
        {
            ViewBag.UserName = usr["UserName"];
        }

        return true;

    }
  }
}
