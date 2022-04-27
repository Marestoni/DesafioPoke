using DesafioPOKE.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DesafioPOKE.Files
{
    public class Files
    {
        public void GenerateArchiveTxt(List<Pokemon> pokemons)
        {
            try
            {
                Directory.SetCurrentDirectory(@"..\..\..\Archives");
                string path = Directory.GetCurrentDirectory();
                var archives = Directory.GetFiles(path, "*.txt");
                foreach (var archive in archives)
                {
                    File.Delete(archive);
                }
                if (pokemons.Count > 0)
                {
                    try
                    {
                        StreamWriter archivePokemon = new StreamWriter(Path.Combine(path, "pokemon.txt"), true);
                        foreach (var pokemon in pokemons)
                        {
                            archivePokemon.WriteLine(pokemon + "\n");
                        }
                        archivePokemon.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Message :{0} ", e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        public void DownloadImages(Dictionary<string, string> images)
        {
            try
            {
                Directory.SetCurrentDirectory(@"..\..\..\Images");
                string path = Directory.GetCurrentDirectory();
                var archives = Directory.GetFiles(path, "*.png");
                foreach (var archive in archives)
                {
                    File.Delete(archive);
                }
                if (images.Count > 0)
                {
                    try
                    {
                        using WebClient webClient = new();
                        foreach (var image in images)
                        {
                            webClient.DownloadFile(new Uri(image.Value), image.Key + ".png");
                        }
                        webClient.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Message :{0} ", e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
