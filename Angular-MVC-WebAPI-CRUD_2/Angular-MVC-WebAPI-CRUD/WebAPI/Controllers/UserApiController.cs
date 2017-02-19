using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class UserApiController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        //[HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }

        [HttpPost]
        public HttpResponseMessage AddUser(User model)
        {
            HttpResponseMessage response;
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                response = new HttpResponseMessage(HttpStatusCode.Created); //201
                response.Content = new StringContent("created"); //created
            }
            catch (Exception)
            {
                response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateUser(int id,User model)
        {
            HttpResponseMessage response;
            try
            {
                if (id == model.UserId)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    response = new HttpResponseMessage(HttpStatusCode.Accepted); //201
                    response.Content = new StringContent("updated"); //updated
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                }
            }
            catch (Exception)
            {
                response = new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            return response;
        }

        public bool DeleteUser(int id)
        {
            User user= db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
