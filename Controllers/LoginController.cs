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
        public string _frmPassword2 {get; set;}
        public string _UserType {get; set;}

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

        public IActionResult Login(string frmUserName, string frmPassword, string UserType, string frmPassword2)
        {
            _frmUserName = frmUserName;
            _frmPassword = frmPassword;
            _UserType = UserType;
            bool result = false;;

            ViewBag.Test = _UserType;
            if(_UserType == "NewUser")
            {
                //register new user here
                result = RegisterNewUser(_frmUserName,_frmPassword,_frmPassword2);
                return View("Login");
            }
            else{

            

                    bool ActiveUser =  UserVerified(_frmUserName,_frmPassword);
                    if(ActiveUser)
                    {
                        //login successful and now redirect user to Member's home screen
                        ViewBag.UserName = _frmUserName;
                        return View("");
                    }  
                    else
                    {
                        //login was not successfull. let user to try again or create a new id
                        
                        ViewBag.VerifiedUser = ActiveUser.ToString();
                        
                        ViewBag.Info = "Invalid Username or password. Please try again!";
                            return View("Login");
                    }
                    
            }
           
        }
        //Add new user to the database
        public bool RegisterNewUser(string UserName, string frmPassword1, string frmPassword2 ){
            if(frmPassword1 == frmPassword2)
            {
                string insertQry = "Insert into Users (FirstName,LastName,UserName,Password,CreatedDate,LogedOutDate) ('firstname','lastname',"+ UserName +"', '"+ frmPassword1 +"',"+ DateTime.Now +","+ DateTime.Now +")";
                return true;
            }
            else
                {
                    return false;
                }
            
        }
        //verify user with database
        public bool UserVerified(string UserName, string password)
        {
            string qry = "select username from Users Where username='"+ UserName +"' and password = '"+ password +"'";
            var mylist = DbConnector.ExecuteQuery(qry);
            

            if(mylist.Count!=0)
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
                }
                
        return true;  
           
        }
    }
}
