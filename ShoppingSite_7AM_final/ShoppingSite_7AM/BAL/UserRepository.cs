using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
namespace BAL
{
    public class UserRepository : IUserRepository
    {
        DatabaseContext db = new DatabaseContext();
        public UserViewModel ValidateUser(LoginViewModel model)
        {
            User data = db.Users.Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();
            
            UserViewModel obj = new UserViewModel();
            
            if (data != null)
            {
                obj.UserId = data.UserId;
                obj.Username = data.Username;
                obj.Name = data.Name;
                obj.ContactNo = data.ContactNo;
                obj.Roles = data.Roles.Select(r => r.Name).ToArray();
            }
            return obj;
        }
    }
}
