using DesafioPOKE.Client;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DesafioPOKE
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string[] pokemons = { "charmander", "squirtle", "caterpie", "weedle", "pidgey", "pidgeotto", "rattata", "spearow", "fearow", "arbok", "pikachu", "sandshrew" };

            var apiClient = new PokeApiClient();
            var files = new Files.Files();


            var (pokemonsList, pokemonImages) = await apiClient.GetPokemon(pokemons);

            if (pokemonsList.Count > 0)
            {
                files.GenerateArchiveTxt(pokemonsList);
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }
            if (pokemonImages.Count > 0)
            {
                files.DownloadImages(pokemonImages);
                Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            }
        }
    }
}
