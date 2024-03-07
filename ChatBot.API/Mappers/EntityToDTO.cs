using ChatBot.API.DTOs;
using ChatBot.DAL.Entities;

namespace ChatBot.API.Mappers
{
    public static class EntityToDTO
    {
        public static ProductDTO ToDTO(this Product p)
        {
            return new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                AudioDesc = p.AudioFileName,
                Image = p.ImageFileName,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
            };
        }
    }
}
