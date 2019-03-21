using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public static class ApiClient
    {
        public static TResponse Get<TResponse>(string path)
        {
            var result = default(TResponse);
            var clientHandler = new HttpClientHandler() { UseDefaultCredentials = true };

            var client = new HttpClient(clientHandler) { Timeout = TimeSpan.FromMinutes(60) };

            client.GetAsync(path).ContinueWith(responseTask =>
            {
                responseTask.Result.Content.ReadAsStringAsync().ContinueWith(readTask =>
                {
                    var taskResult = readTask.Result;

                    result = taskResult.JsonParseAs<TResponse>();
                }).Wait();
            }).Wait();

            return result;
        }

        public static TResponse Post<TRequest, TResponse>(TRequest request, string path)
        {
            var result = default(TResponse);
            var clientHandler = new HttpClientHandler()
            {
                UseDefaultCredentials = true,
            };

            var client = new HttpClient(clientHandler);
            var body = request.ToJson();
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            client.PostAsync(path, content).ContinueWith(responseTask =>
            {
                responseTask.Result.Content.ReadAsStringAsync().ContinueWith(readTask =>
                {
                    result = readTask.Result.JsonParseAs<TResponse>();
                }).Wait();
            }).Wait();

            return result;
        }
    }
}
