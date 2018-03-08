using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using E_ATM.Models;

namespace E_ATM.Controllers
{
    public class E_ATMController : Controller
    {
        public ApplicationDbContext ctx;

        public E_ATMController()
        {
            ctx = new ApplicationDbContext();

        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Details(Accounts account)
        {
            var act = ctx.Accountses.FirstOrDefault(a => a.CardNumber == account.CardNumber && a.PinNumber == account.PinNumber);

            if (act == null)
            {
                Session["msg"] = "Your Card Number and Pin Number doesn't match";
                return RedirectToAction("New", "E_ATM");

            }
            else
            {
                
                Session["New"] = true;
                return RedirectToAction("Options","E_ATM", new { cardNumber = account.CardNumber });

            }
        }


        [Route("E_ATM/{CardNumber}/Options")]
        public ActionResult Options(int cardNumber)
        {
            var accounts = GetAccount(cardNumber);
            return View(accounts);

        }
        public ActionResult Register()
        {
            return View();
        }
        [Route("E_ATM/RegisterSuccessful")]
        public ActionResult RegisterSuccessful(Accounts account)
        {
            var act = ctx.Accountses.FirstOrDefault(m => m.CardNumber == account.CardNumber);
            if (act != null)
            {
                Session["msg"] = "Card Number is Already Uses, Please enter another Card Number.";
                return RedirectToAction("Register", "E_ATM");
            }
            else
            {
                ctx.Accountses.Add(account);
                ctx.SaveChanges();
                Session["New"] = true;
                return RedirectToAction("New", "E_ATM", new { cardNumber = account.CardNumber });
            }


        }
        [Route("E_ATM/{CardNumber}/BalanceCheck")]
        public ActionResult BalanceCheck(int CardNumber)
        {
            var accounts = GetAccount(CardNumber);
            return View(accounts);
        }
        [Route("E_ATM/{cardNumber}/CashWithdrawal")]
        public ActionResult CashWithdrawal(int cardNumber)
        {
            var account = GetAccount(cardNumber);

            var totalTransaction = GetTranctionNumber(cardNumber);
            if (totalTransaction.Count > 2)

            {

                Session["msg"] = "Your Daily transtion limit is finish.";
                return RedirectToAction("Options", "E_ATM", new { cardNumber = account.CardNumber });
            }

            return View(account);
        }
        [Route("E_ATM/{CardNumber}/cashSuccessful")]
        public ActionResult cashSuccessful(int CardNumber, int amount)
        {
            var account = GetAccount(CardNumber);

            if (account.Balance>amount)
            {
                var transaction = new Transaction();
                transaction.Id = transaction.Id + 1;
                transaction.CardNUmber = account.CardNumber;
                transaction.Amount = amount;


                account.Balance = account.Balance - amount;
                transaction.Balance = account.Balance;
                ctx.Transactions.Add(transaction);
                ctx.SaveChanges();
                return View(account);
            }
            else
            {
                Session["msg"] = "You have not enough balance for cashwithdrawal!";
                return RedirectToAction("CashWithdrawal", new {cardnumber = account.CardNumber});
            }

            
        }

        public ActionResult History(int cardNumber)
        {
            var get = ctx.Transactions.Where(c => c.CardNUmber == cardNumber).ToList();


            return View(get);
        }



        public ActionResult Logout(int cardNumber)
        {
            Session["New"] = null;
            var transaction = GetTranctionNumber(cardNumber);

            if (transaction.Count > 2)
            {
                ctx.Transactions.RemoveRange(transaction);
                ctx.SaveChanges();
            }

            return RedirectToAction("New", "E_ATM");
        }

        private Accounts GetAccount(int cardNumber)
        {
            return ctx.Accountses.FirstOrDefault(a => a.CardNumber == cardNumber);
        }

        public List<Transaction> GetTranctionNumber(int cardNumber)
        {
            return ctx.Transactions.Where(a => a.CardNUmber == cardNumber).ToList();
        }




        

    }
}