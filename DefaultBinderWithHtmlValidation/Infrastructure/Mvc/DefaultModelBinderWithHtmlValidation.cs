using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultBinderWithHtmlValidation.Infrastructure.Mvc
{

    public class DefaultModelBinderWithHtmlValidation : DefaultModelBinder
    {

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                return base.BindModel(controllerContext, bindingContext);
            }
            catch (HttpRequestValidationException)
            {
                Trace.TraceWarning("Illegal characters were found in field {0}", bindingContext.ModelMetadata.DisplayName ?? bindingContext.ModelName);
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Ilegal characters were found in field {0}", bindingContext.ModelMetadata.DisplayName ?? bindingContext.ModelName));
            }

            //Cast the value provider to an IUnvalidatedValueProvider, which allows to skip validation
            IUnvalidatedValueProvider provider = bindingContext.ValueProvider as IUnvalidatedValueProvider;
            if (provider == null) return null;

            //Get the attempted value, skiping the validation
            var result = provider.GetValue(bindingContext.ModelName, skipValidation: true);
            Debug.Assert(result != null, "result is null");

            return result.AttemptedValue;
        }
    }
}
