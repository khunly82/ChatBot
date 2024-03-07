using ChatBot.DAL;
using ChatBot.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.BLL.Services
{
    public class ProductService
    {
        private readonly OpenAIContext _context;
        private readonly AudioService _audioService;

        public ProductService(
            OpenAIContext context, 
            AudioService audioService
        )
        {
            _context = context;
            _audioService = audioService;
        }

        public async Task Add(string name, string description, IFormFile? file)
        {
            string audioFile = await _audioService.GetAudio(description);

            string imageFileName = Guid.NewGuid().ToString() + file?.FileName;

            using Stream stream = File.Create(
                Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images", imageFileName)    
            );

            string path = Environment.CurrentDirectory;


            await file?.CopyToAsync(stream);

            _context.Add(new Product
            {
                Name = name,
                Description = description,
                AudioFileName = audioFile,
                ImageFileName = imageFileName,
                CategoryId = 1
            });

            _context.SaveChanges();
        }
    }
}
