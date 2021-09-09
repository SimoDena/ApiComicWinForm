using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace apiComicWinForm
{
    public class ComicProcessor
    {
        public int MaxNumber { get; set; }

        public static async Task<Comic> CaricaComic(int numeroComic = 0)
        {
            string url = "";

            if (numeroComic > 0)
            {
                url = $"https://xkcd.com/{ numeroComic }/info.0.json";
            }
            else
            {
                url = "https://xkcd.com/info.0.json";
            }

            HttpResponseMessage risposta = await ApiHelper.ApiClient.GetAsync(url);

            if (risposta.IsSuccessStatusCode)
            {
                Comic comic = await risposta.Content.ReadAsAsync<Comic>();
                return comic;
            }
            else
            {
                throw new Exception(risposta.ReasonPhrase);
            }
        }
    }
}
