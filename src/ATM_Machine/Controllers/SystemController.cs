using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

public class SystemController : Controller
{

    public IActionResult Index(){
        var id = Request.Cookies["email"];
        DatabaseMethods database = new DatabaseMethods();
        var valuedatabase = database.montUser(id);
        
        return View("Index", valuedatabase);
    }

    public ActionResult Logout()
    {
        if (Request.Cookies["email"] != null)
        { 
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Append("email", "as", options);
            return StatusCode(200);
        }
        return StatusCode(200);
    }

    public ActionResult Deposit(double valueToDeposit, string transactType)
    {
        var id = Request.Cookies["email"];
        DatabaseMethods database = new DatabaseMethods();
        database.changeCredits(id, valueToDeposit, transactType);

        return StatusCode(201);
    }
    public ActionResult Withdraw(double valueToWithdraw, string transactType)
    {
        var id = Request.Cookies["email"];
        DatabaseMethods database = new DatabaseMethods();
        var negativeWithdraw = -valueToWithdraw;
        database.changeCredits(id, negativeWithdraw, transactType);

        return StatusCode(201);

    }

    public ActionResult Transfer(double valueToTransfer, string emailToTransfer, string transactType)
    {

        var id = Request.Cookies["email"];
        DatabaseMethods database = new DatabaseMethods();
        var valueToTransferNegative = -valueToTransfer;
        var cadastred = database.verifyCadastredEmail(emailToTransfer);
        if(cadastred == false)
        {
            database.changeCredits(id, valueToTransferNegative, transactType);
            database.changeCredits(emailToTransfer, valueToTransfer, transactType);
            return StatusCode(201);

        }else
        {
            return StatusCode(500);
        }
    }
}