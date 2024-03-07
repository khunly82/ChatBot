using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Models
{
    public class ChatQueryModel
    {
        public string Model { get; set; } = "gpt-3.5-turbo";

        public List<ChatMessageModel> Messages { get; set; } = new List<ChatMessageModel>();
    }
}
