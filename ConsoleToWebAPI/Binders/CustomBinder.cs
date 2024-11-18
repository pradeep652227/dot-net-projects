using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace ConsoleToWebAPI.Binders
{
    public class CustomBinder : IModelBinder
    {
        Task IModelBinder.BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;//get the data from query string
            var result = data.TryGetValue("countries", out var country);//

            if (result)
            {
                var array=country.ToString().Split('|');
                bindingContext.Result = ModelBindingResult.Success(array);

            }

            return Task.CompletedTask;
        }
    }
}
