using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ConsoleToWebAPI.Models
{
    public class CountryModel
    {
        public string Name { get; set; }
        public string Population { get; set; }
        public int Area { get; set; }
    }
}
