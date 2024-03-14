using CleaArchMVC.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleaArchMVC.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "ID inválido!");
            ID = id;
            ValidateDomain(name);
        }

        public void update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
                "Nome inválido!"
                );
            DomainExceptionValidation.When(name.Length < 4,
                "Nome inválido, nome muito curto!"
                );

            Name = name;

        }

    }
}
