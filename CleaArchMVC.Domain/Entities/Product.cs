using CleaArchMVC.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaArchMVC.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set;  }
        public int Stock { get; private set; } 
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "ID inválido!");
            ID = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = CategoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido!"
                );
            DomainExceptionValidation.When(name.Length < 4,
                "Nome inválido, nome muito curto!"
                );
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválida!"
                );
            DomainExceptionValidation.When(price < 5,
                "Preço inválido!"
                );
            DomainExceptionValidation.When(stock < 5,
                "Preço inválido!"
                );
            DomainExceptionValidation.When(image?.Length > 250,
                "Nome para imagem inválido!"
                );

            Name = name;
            Description = Description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
