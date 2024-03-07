using ChatBot.BLL.Models;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Services
{
    public class AudioService: OpenAIService
    {
        private readonly IHostEnvironment _env;
        public AudioService(
            HttpClient httpClient,
            IHostEnvironment env
        ): base(httpClient) {
            _env = env;
        }

        public async Task<string> GetAudio(string input)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                "/v1/audio/speech", 
                new AudioQueryModel(input)
            );

            if(!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            using Stream stream = await response.Content.ReadAsStreamAsync();
            string fileName = Guid.NewGuid().ToString() + ".mp3";
            string path = Path.Combine(
                _env.ContentRootPath,
                "wwwroot",
                "Audios",
                fileName
            );
            using Stream output = File.Create(path);
            stream.CopyTo(output);
            return fileName;
        }

    }
}
