using ChatBot.API.DTOs;
using ChatBot.BLL.Models;
using ChatBot.BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;   
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MessageDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Send([FromBody] List<MessageForm> messages)
        {

            try
            {
                List<ChatMessageModel> messagesResult = await _chatService.RequestChat(messages
                                                .Select(m => new ChatMessageModel
                                                    { 
                                                        Content = m.Content,
                                                        Role = m.Role  
                                                    }).ToList());

                return Ok(messagesResult.Select(m => new MessageDTO(m)));
            }
            catch (HttpRequestException httpEx)
            {
                return BadRequest(httpEx.Message);
            }
            catch (ArgumentException argEx)
            {
                return Problem(argEx.Message);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
