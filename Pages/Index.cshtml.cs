using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PetConnectPartner.Models;
using PetConnectPartner.Services;

namespace PetConnectPartner.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AnimalApiClient _api;

        public List<AnimalDto> Animals { get; set; } = new List<AnimalDto>();
        public IndexModel(AnimalApiClient api)
        {
            _api = api;
        }

   
        public async Task OnGetAsync()
        {
            Animals = await _api.GetAnimalsAsync();

            Console.WriteLine($"Animals loaded: {Animals.Count}");
        }
    }
}

