using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    
    public IActionResult Index(){
        return View();
    }
    [HttpPost]
    public ActionResult Login(string email, string password){

        DatabaseMethods database = new DatabaseMethods();
        bool login = database.loginDatabase(email, password);

        if(login == true){
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("email", email, options);
            return StatusCode(200);
        }else{
            return StatusCode(403);
        }
    }
    
   
}