using Microsoft.AspNetCore.Mvc;
using PetConnectPartner.Models;

namespace PetConnectPartner.Services
{
    public class AnimalApiClient
    {
        private readonly HttpClient _http;

        public AnimalApiClient(HttpClient http)
        {
            _http = http;
        }

        //GET ALL ANIMALS - INDEX PAGE
        public async Task<List<AnimalDto>> GetAnimalsAsync()
        {
            return await _http.GetFromJsonAsync<List<AnimalDto>>("api/AnimalsApi/Search");
        }

        
        // GET ANIMALS BY TYPE OR CITY STATE - ANIMALS PAGE
        public async Task<List<AnimalDto>> SearchAnimalsAsync(string city, string state, string animalTypeName)
        {
            // Use the exact same path pattern as GetAnimalsAsync
            var url = $"api/AnimalsApi/Search?city={city}&state={state}&animalTypeName={animalTypeName}";

            return await _http.GetFromJsonAsync<List<AnimalDto>>(url);
        }

        //GET ANIMAL DETAILS BY ID - DETAILS PAGE
        public async Task<AnimalDto?> GetAnimalByIdAsync(int id)
        {
            // Use consistent path pattern
            return await _http.GetFromJsonAsync<AnimalDto>($"api/AnimalsApi/{id}");
        }
    }
}
