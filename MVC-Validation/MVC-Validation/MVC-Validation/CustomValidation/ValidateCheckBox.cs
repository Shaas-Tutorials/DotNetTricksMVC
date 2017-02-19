using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVC_Validation.CustomValidation
{
    public class ValidateCheckBox : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return (bool)value;

            //if ((bool)value == true)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new ModelClientValidationRule[] { new ModelClientValidationRule { ErrorMessage = this.ErrorMessage, ValidationType = "checkbox" } };
        }
    }
}