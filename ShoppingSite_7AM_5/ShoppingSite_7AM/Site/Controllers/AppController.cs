using BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace Site.Controllers
{
    public class AppController :BaseController
    {
        IOrderRepository repo;

        public AppController(IOrderRepository _repo)
        {
            repo = _repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Success(FormCollection form)
        {
            try
            {
                string salt = "eCwWELxi";

                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

                if (form["status"].ToString() == "success")
                {
                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    // merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + form["status"].ToString();

                    merc_hash_string = salt + "|" + form["status"].ToString();

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");
                    }

                    //  Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();

                    if (merc_hash != form["hash"])
                    {
                        // Response.Write("Hash value did not matched");
                        ViewData["Message"] = "Hash value did not matched";
                    }
                    else
                    {
                        //Response.Write("<br/>Hash value matched");

                        TransactionViewModel model = new TransactionViewModel();

                        model.CartId = Convert.ToInt32(form["udf1"]);
                        model.Amount = Convert.ToDecimal(form["amount"]);
                        model.PaymentType = "Payment Gateway";
                        model.Status = form["status"];
                        model.TransactionId = Request.Form["txnid"];

                        model.CreatedDate = DateTime.Now;
                        model.UpdatedDate = DateTime.Now;
                        model.Name = form["firstname"];
                        
                        repo.PlaceOrder(model);

                        ReceiptViewModel obj = new ReceiptViewModel();
                        obj.Name = form["firstname"];
                        obj.Email = form["email"];
                        obj.TransactionId = form["txnid"];
                        obj.Amount = form["amount"];
                        obj.Status = form["status"];

                        ViewData["Message"] = "Your order has been placed successfully!";
                        return View(obj);
                    }
                }
                else
                {
                    // Response.Write("Hash value did not matched");
                }
            }
            catch (Exception ex)
            {
                //Response.Write("<span style='color:red'>" + ex.Message + "</span>");
            }
            return View();
        }

        public string Generatehash512(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}