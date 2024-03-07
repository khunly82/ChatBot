using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Models
{
    public class AudioQueryModel
    {
        public AudioQueryModel(string input)
        {
            Input = input;
        }

        public string Model { get; set; } = "tts-1";
        public string Voice { get; set; } = "onyx";

        public string Input { get; set; }
    }
}
