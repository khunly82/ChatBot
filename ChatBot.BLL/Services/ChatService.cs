using ChatBot.BLL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Services
{
    public class ChatService: OpenAIService
    {
        public ChatService(HttpClient httpClient): base(httpClient)
        {
        }
        public async Task<List<ChatMessageModel>> RequestChat(List<ChatMessageModel> messages)
        {
            // TODO : Faire la requête
            // Post
            // -> 1er param : Url
            // -> 2ème param : Objet à envoyer
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/v1/chat/completions", new ChatQueryModel {  Messages = messages } );

            // TODO : Traiter le résultat
            string content = await response.Content.ReadAsStringAsync();

            // si la requête n'a pas réussi, on renvoie une erreur
            if (!response.IsSuccessStatusCode )
            {
                throw new HttpRequestException(content, null, response.StatusCode);
            }

            // TODO : Envoyer les messages reçus en réponse
            // Installer Nuggets Package Newtonsoft.Json
            return JsonConvert.DeserializeObject<ChatResponseModel>(content)?.Choices.Select(choice => choice.Message).ToList() ?? throw new ArgumentException("Deserialization Issue");

            //return (JsonConvert.DeserializeObject<ChatResponseModel>(content)?.Choices.Select(choice => choice.Message).ToList()) is not null ? JsonConvert.DeserializeObject<ChatResponseModel>(content)?.Choices.Select(choice => choice.Message).ToList() : throw new ArgumentException("Deserialization Issue");
        }

    }
}
