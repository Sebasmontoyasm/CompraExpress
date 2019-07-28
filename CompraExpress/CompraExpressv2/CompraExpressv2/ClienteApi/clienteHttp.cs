using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CompraExpressv2.ClienteApi
{
    public class clienteHttp
    {
        private String UriApi;
        MediaTypeWithQualityHeaderValue mediaheader;
        public clienteHttp() {
            //this.UriApi = "http://localhost:50809/"; // Local API
            this.UriApi = "http://agendaexampleapi.azurewebsites.net/"; // Azure API
            this.mediaheader = new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json");



        }
        /**
        public async Task<List> GetContacts()
        {
            using (HttpClient client = new HttpClient())
            {
                String petition = "api/Contacts";
                client.BaseAddress = new Uri(this.UriApi);
                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaheader);
                HttpResponseMessage respuesta = await client.GetAsync(petition);
                if (respuesta.IsSuccessStatusCode)
                {
                    List cList = await respuesta.Content.ReadAsAsync<List>();
                    return cList;
                }
                else { return null; }
            }
        }
        */
    }
    
}
