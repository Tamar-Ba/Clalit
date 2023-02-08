using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Logic.LogicServices;

namespace Logic
{
    public class Rates :IRates
    {
        private readonly IConfiguration _config;

        public Rates(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GetExchangeRateAsync()
        {
            var API = _config.GetSection("ExternalApi").Value;

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(API);

            string apiResponse = await response.Content.ReadAsStringAsync();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(apiResponse);
            var jsonData = JsonConvert.SerializeXmlNode(xmlDoc);

            return jsonData;
        }
    }
}
