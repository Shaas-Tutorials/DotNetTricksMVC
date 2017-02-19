using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Client.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage="Please Enter Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
    }
}