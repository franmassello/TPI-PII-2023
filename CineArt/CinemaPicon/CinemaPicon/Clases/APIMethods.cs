﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace CinemaPicon.Clases
{
    public class APIMethods
    {
        public string API_URL = "https://localhost:7164"; // Replace with your actual API URL

        public async Task<string> Login(string username, string password)
        {
            string url = $"{API_URL}/login?user={username}&password={password}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url, null);


                if (response.IsSuccessStatusCode)
                {
                    return "Login successful";
                }
                else
                {
                    string errorMessage = $"Login failed with status code {response.StatusCode}";
                    string responseBody = await response.Content.ReadAsStringAsync();
                    errorMessage += $"\n{responseBody}";
                    return errorMessage;
                }
            }
        }


        public async Task<DataTable> consultarTabla(string nombreTabla)
        {
            string url = $"{API_URL}/{nombreTabla}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // the endpoint returns an array of objects, so we need to deserialize it
                string responseBody = await response.Content.ReadAsStringAsync();
                DataTable tabla = JsonConvert.DeserializeObject<DataTable>(responseBody);
                return tabla;
            }
        }

        // create a method to do a put 

        public async Task<string> PutPelicula(string nombreRuta, string id, string json)
        {
            string url = $"{API_URL}/{nombreRuta}?idPelicula={id}";

            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return "Update successful";
                }
                else
                {
                    return "Update failed";
                }
            }
        }
        
        // now i need a method to do a delete passing a ID

        public async Task<string> DeletePelicula(string nombreRuta, string id)
        {
            string url = $"{API_URL}/{nombreRuta}?idPelicula={id}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return "Delete successful";
                }
                else
                {
                    return "Delete failed";
                }
            }
        }



    }
}
