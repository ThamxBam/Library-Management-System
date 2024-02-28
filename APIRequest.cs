using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using RestSharp;

namespace ASSIGMENT11._2
{
    public class APIRequest
    {
        public List<Doc> Docs { get; set; }
    }

    public class OpenLibraryService
    {
        private const string BaseUrl = "https://openlibrary.org/";
        private readonly RestClient _client;

        public OpenLibraryService()
        {
            _client = new RestClient(BaseUrl);
        }

        public List<Doc> SearchBooks(string query, string searchType)
        {
            var request = new RestRequest("search.json", Method.Get);
            request.AddParameter(searchType, query);

            var response = _client.Execute<APIRequest>(request);

            if (response.IsSuccessful)
            {
                return response.Data?.Docs;
            }
            return null;
        }
    }
}
