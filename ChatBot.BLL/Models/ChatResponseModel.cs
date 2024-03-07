using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Models
{
    public class ChatResponseModel
    {
        public List<Choice> Choices { get; set; } = new List<Choice>();
        public int Created { get; set; }
        public string Id { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Object { get; set; } = string.Empty;
        public Usage Usage { get; set; } = new Usage();
    }

    public class Choice
    {
        public string Finish_Reason { get; set; } = string.Empty;
        public int Index { get; set; }
        public ChatMessageModel Message { get; set; } = new ChatMessageModel();
        public string Logprobs { get; set; } = string.Empty;
    }

    public class Usage
    {
        public int Completion_Tokens { get; set; }
        public int Prompt_Tokens { get; set; }
        public int Total_Tokens { get; set; }
    }
}
