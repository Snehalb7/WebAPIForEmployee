using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace WebAPIForEmployee.Filter
{
    public class MyActionFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext con)
        {
            Console.WriteLine("Action Filter Executing");
        }

        public override void OnActionExecuted(ActionExecutedContext con)
        {
            Console.WriteLine("Action Filter Executed");
        }
    }
}
