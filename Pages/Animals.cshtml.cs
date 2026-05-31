



//using Microsoft.AspNetCore.Mvc.RazorPages;
//using PetConnectPartner;

//namespace PetConnectPartner.Pages
//{
//    public class AnimalsModel : PageModel
//    {
//        private readonly AnimalApiClient _api;

//        public List<AnimalDto> Animals { get; set; } = new();

//        public AnimalsModel(AnimalApiClient api)
//        {
//            _api = api;
//        }

//        public async Task OnGet( string location, string type)
//        {
//            // Simple split - assumes "City, State" format
//            var parts = location?.Split(',') ?? new string[0];
//            var city = parts.Length > 0 ? parts[0].Trim() : null;
//            var state = parts.Length > 1 ? parts[1].Trim() : null;

//            Animals = await _api.SearchAnimalsAsync(city, state, type);
//        }


//    }
//}

using Microsoft.AspNetCore.Mvc.RazorPages;
using PetConnectPartner;
namespace PetConnectPartner.Pages
{
    public class AnimalsModel : PageModel
    {
        private readonly AnimalApiClient _api;
        public List<AnimalDto> Animals { get; set; } = new();

        public AnimalsModel(AnimalApiClient api)
        {
            _api = api;
        }

        public async Task OnGet(string animalTypeName, string location)
        {
            // Parse location (expects "City, State" or just "City")
            string? city = null;
            string? state = null;

            if (!string.IsNullOrWhiteSpace(location))
            {
                var parts = location.Split(',');
                city = parts[0].Trim();
                if (parts.Length > 1)
                    state = parts[1].Trim();
            }

            // Your API doesn't have a breed parameter - check your AnimalApiSearchFilter
            // If breed isn't supported, remove it or add it to your API
            Animals = await _api.SearchAnimalsAsync(city, state, animalTypeName);
        }
    }
}