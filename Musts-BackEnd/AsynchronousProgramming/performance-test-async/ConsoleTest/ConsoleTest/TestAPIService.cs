using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class TestAPIService
    {
        public void CallPostProduct(string url, List<ProductItem> productList)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type:application/json");
                client.Headers.Add("Accept:application/json");
                var result = client.UploadString(url, JsonConvert.SerializeObject(productList));
            }
        }
    }
}
