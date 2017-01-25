using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections;
using MongoDB.Driver.Builders;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATM_Machine.Controllers
{
    public class TransactsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var id = Request.Cookies["email"];
            DatabaseMethods database = new DatabaseMethods();
            var valuedatabase = database.montUser(id);
            var users = new List<BsonDocument>();
           

            return View("Index");
        }
    }
}
