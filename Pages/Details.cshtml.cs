
//using Microsoft.AspNetCore.Mvc.RazorPages;

//public class AnimalDetailsModel : PageModel
//{
//    private readonly HttpClient _httpClient;

//    public AnimalDetailsModel(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }

//    public Animal Animal { get; set; }

//    public async Task OnGetAsync(int id)
//    {
//        Animal = await _httpClient.GetFromJsonAsync<Animal>(
//            $"https://localhost:7207/api/AnimalsApi/{Id}"
//        );
//    }
//}



using Microsoft.AspNetCore.Mvc.RazorPages;
using PetConnectPartner.Models;
using PetConnectPartner.Services;

public class AnimalDetailsModel : PageModel
{
    private readonly AnimalApiClient _animalApiClient;

    public AnimalDetailsModel(AnimalApiClient animalApiClient)
    {
        _animalApiClient = animalApiClient;
    }

    public AnimalDetailsDto Animal { get; set; }

    public async Task OnGetAsync(int id)
    {
        Animal = await _animalApiClient.GetAnimalByIdAsync(id);
    }
}