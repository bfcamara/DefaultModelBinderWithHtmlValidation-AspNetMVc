using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DefaultBinderWithHtmlValidation.Models;

namespace DefaultBinderWithHtmlValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FieldArgument = "";
            var model = new MyModel()
            {
                MyArrayOfStrings = new string[] { "", "" }
            };
            return View(model );
        }

        [HttpPost]
        public ActionResult Create(MyModel model, string fieldArgument)
        {

            if (ModelState.IsValid)
            {
                //The model is OK. We can do whatever we want to do with the model
                model.MyMessage = "Model Ok Updated @ " + DateTime.Now;
            }

            ViewBag.FieldArgument = fieldArgument;
            return View(model);
        }
    }
}
