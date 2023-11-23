using System;
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

        /**
        // i need to do a get to my api like this, i will need to make a get 
        
        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = oDato.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;


        } 

        **/

        // The data the api returns i need to load it to a combobox
        // it should return a datatable
        // the method im trying to replace is this one consultarTabla
        /**
        public DataTable consultarTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;//hay que dejar el espacio en blanco despues del from
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;

        }
        **/

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
        
        



    }
}
