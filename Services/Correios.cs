using Parallelismo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Parallelismo.Service
{
    public class Correios
    {

        public Address GetCEP(string CEP)
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync("https://viacep.com.br/ws/" + CEP + "/json/").Result;
            var json = response.Content.ReadAsStringAsync().Result;



            if (response.IsSuccessStatusCode)
            {
                var jsonobject = JsonConvert.DeserializeObject<Address>(json);
                return jsonobject;
            }
            return null;
        }
    }
}
