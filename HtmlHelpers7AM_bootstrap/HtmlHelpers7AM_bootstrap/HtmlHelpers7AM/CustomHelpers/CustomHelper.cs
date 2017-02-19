using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
namespace HtmlHelpers7AM.CustomHelpers
{
    public static class CustomHelper
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string value, string name)
        {
            string str = "<input type='submit' value='" + value + "' name='"+name+"'>";
            return new MvcHtmlString(str);
        }

        public static string strSubmitButton(this HtmlHelper helper, string value,string name)
        {
            return "<input type='submit' value='" + value + "' name='" + name + "'>";
        }
    }
}