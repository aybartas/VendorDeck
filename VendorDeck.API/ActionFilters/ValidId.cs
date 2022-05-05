using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using VendorDeck.Business.Interfaces;

namespace VendorDeck.API.ActionFilters
{
    public class ValidId<T> : IActionFilter where T : class
    {
        IGenericService<T> genericService;

        public ValidId(IGenericService<T> genericService)
        {
            this.genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context){}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var parameterDict = context.ActionArguments.Where(I => I.Key.Equals("id")).FirstOrDefault();
            var requestedId = (int)parameterDict.Value;
            var entity =   genericService.FindByIdAsync(requestedId).Result;

            if (entity == null) 
                context.Result = new NotFoundObjectResult($"There is no object with Id: {requestedId}");
        }
    }
}
