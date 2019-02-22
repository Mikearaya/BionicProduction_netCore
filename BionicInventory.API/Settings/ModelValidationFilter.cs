using BionicInventory.API.Commons;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BionicInventory.API.Settings {
    public class ModelValidationFilter : ActionFilterAttribute {
        public override void OnActionExecuting (ActionExecutingContext context) {
            if (!context.ModelState.IsValid) {
                context.Result = new InvalidInputResponse (context.ModelState); // returns 422 with error

            }
        }
    }

}