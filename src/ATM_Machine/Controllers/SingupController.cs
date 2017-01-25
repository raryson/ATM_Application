using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SingupController : Controller {
    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Register(string email, string password, int age, string name){
        var user = new User();
        user.setEmail(email);
        user.setPassWord(password);
        user.setAge(age);
        user.setName(name);

        var bsoncontent = new BsonDocument { { "logs", new BsonDocument { { "transcatType", "Your first log" }, { "valueTransact", "Your first log" }, { "dateTransact", "Your first log" } } } };
        var users = new List<BsonDocument>();
        users.Add(bsoncontent);

        user.logs = users;

        DatabaseMethods database = new DatabaseMethods();
        bool emailVerify = database.verifyCadastredEmail(user.email);

        if(emailVerify == true){
            bool status = database.registerSingedUp(user);
            if(status == true){
                return StatusCode(201);
            }else{
                return StatusCode(500);
            }
        }else{
            return StatusCode(409);
        }
    }
}