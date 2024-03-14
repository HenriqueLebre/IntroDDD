using System.ComponentModel.DataAnnotations;

namespace CleaArchMVC.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is Required")]
        public string Name { get; set; }
    }
}
