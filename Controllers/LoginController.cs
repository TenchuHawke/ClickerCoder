using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace clickerCoder.Controllers
{
    public class LoginController : Controller
    {
        public string _frmUserName {get;set;}
        public string _frmPassword {get;set;}

        // GET: /Home/
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            //bool resultFlag = false;
            getUserList();
            return View("Login");
        }

        [HttpPostAttribute]
        [RouteAttribute("Login")]

        public IActionResult Login(string frmUserName, string frmPassword)
        {
            _frmUserName = frmUserName;
            _frmPassword = frmPassword;

           bool ActiveUser =  UserVerified(_frmUserName,_frmPassword);
           ViewBag.VerifiedUser = ActiveUser.ToString();
           return View("Login");
        }
        
        public bool UserVerified(string UserName, string password)
        {
            string qry = "select username from Users Where username='"+ UserName +"' and password = '"+ password +"'";
            if(DbConnector.ExecuteQuery(qry) != null)
            {
                return true;
            }
            else
                {
                    return false;
                }

        }
        public bool getUserList()
        {
            
                string selectQry = "select * from Users";
                foreach(var usr in DbConnector.ExecuteQuery(selectQry))
                {
                    //view bag to display user info
                    ViewBag.UserName = usr["UserName"];
/* 
                    Console.WriteLine("ID: {0} \n", usr["idUsers"]);
                    Console.WriteLine("User Name: {0} {1} \n ", usr["FirstName"], usr["LastName"]);
                    Console.WriteLine("LogedOutDate: {0} \n ", usr["LogedoutDate"]);
                    Console.WriteLine("------------------\n");
                    */
                }
                //DbConnector.ExecuteQuery(selectQry);
                 
              return true;  
           
        }
    }
}
