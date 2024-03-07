using ChatBot.DAL;
using ChatBot.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task Add(string name, string description, IFormFile? file, int categoryId)
        {
            string audioFile = await _audioService.GetAudio(description);

            string imageFileName = Guid.NewGuid().ToString() + file?.FileName;

            using Stream stream = File.Create(
                Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images", imageFileName)    
            );

            string path = Environment.CurrentDirectory;


            await file?.CopyToAsync(stream);

            Product added = _context.Products.Add(new Product
            {
                Name = name,
                Description = description,
                AudioFileName = audioFile,
                ImageFileName = imageFileName,
                CategoryId = categoryId
            }).Entity;


            Debug.WriteLine("---------------");
            Debug.WriteLine(added.Id);

            _context.SaveChanges();

            Debug.WriteLine("---------------");
            Debug.WriteLine(added.Id);
        }

        public List<Product> GetProducts()
        {
            // SELECT * FROM Product
            // return _context.Products.ToList();

            // SELECT * FROM Product
            // WHERE Name LIKE '%?%'
            // _context.Products.Where(p => p.Name.Contains(?)).ToList();

            // SELECT p.*, c.*
            // FROM Product p
            // LEFT JOIN Category c ON c.Id = p.CategoryId

            return _context.Products.Include(p => p.Category).ToList();

            //return _context
            //    .Products.Include(p => p.Category)
            //    .Where(p =>
            //    p.Category.Name == "Moto").ToList();
        }
    }
}
