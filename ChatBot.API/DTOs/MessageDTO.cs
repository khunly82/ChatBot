using ChatBot.BLL.Models;

namespace ChatBot.API.DTOs
{
    public class MessageDTO
    {
        public MessageDTO(ChatMessageModel message)
        {
            Role = message.Role;
            Content = message.Content;
            Date = DateTime.Now;
        }
        public string Role { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
