using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Services
{
    public abstract class OpenAIService
    {
        protected readonly HttpClient _httpClient;

        protected OpenAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.openai.com");
        }
    }
}
