using CleaArchMVC.Domain.Entities;

namespace CleaArchMVC.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }
        public Category CategoryId { get; set; }
    }
}
