using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultBinderWithHtmlValidation.Models
{
    public class MyModel
    {
        [Required]
        public string MyName { get; set; }
        public string[] MyArrayOfStrings { get; set; }
        public AnotherModel MyAnotherModel { get; set; }
        
        [AllowHtml]
        public string AnHtmlField { get; set; }

        public string MyMessage { get; set; }
    }

    public class AnotherModel
    {
        [Required]
        public int MyInt { get; set; }
    }
}