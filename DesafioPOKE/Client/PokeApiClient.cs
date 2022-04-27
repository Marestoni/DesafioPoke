using DesafioPOKE.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesafioPOKE.Client
{
    public class PokeApiClient
    {
        public async Task<(List<Pokemon> pokemonsList, Dictionary<string, string> pokemonImages)> GetPokemon(string[] Pokemons)
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/"),
            };
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            ParallelOptions parallelOptions = new()
            {
                MaxDegreeOfParallelism = 3
            };

            List<Pokemon> pokemonsList = new();
            Dictionary<string, string> pokemonImages = new();
            await Parallel.ForEachAsync(Pokemons, parallelOptions, async (uri, token) =>
            {
                var response = await client.GetAsync(uri, token);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error getting pokemon {uri}");
                    throw new Exception($"Error getting pokemon {uri}");
                }
                var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>();

                pokemonsList.Add(pokemon);
                pokemonImages.Add(pokemon.Name, pokemon.Sprites.Front_Default);

                Console.WriteLine(pokemon + "\n");

            });

            return (pokemonsList, pokemonImages);
        }
    }
}
