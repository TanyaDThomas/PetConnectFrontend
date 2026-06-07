

using Microsoft.AspNetCore.Mvc.RazorPages;
using PetConnectPartner.Models;
using PetConnectPartner.Services;
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
            
            string? city = null;
            string? state = null;

            if (!string.IsNullOrWhiteSpace(location))
            {
                var parts = location.Split(',');
                city = parts[0].Trim();
                if (parts.Length > 1)
                    state = parts[1].Trim();
            }

            
            Animals = await _api.SearchAnimalsAsync(city, state, animalTypeName);
        }
    }
}