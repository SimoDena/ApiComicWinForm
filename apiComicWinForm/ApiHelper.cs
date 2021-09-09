using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace apiComicWinForm
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } // serve per fare richieste HTTP.

        public static void InizializzaClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri(""); in questo caso non lo metto così si può usare la classe per più api diverse.
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); //la risposta sarà di tipo json 
        }
    }
}
