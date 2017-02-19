using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace HtmlHelpers7AM.Models
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
     
        public string Username { get; set; }
        public string FullName { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}