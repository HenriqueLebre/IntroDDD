using CleaArchMVC.Domain.Entities;
using FluentAssertions;

namespace CleanArchMov.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WhitValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleaArchMVC.Domain.Validations.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_ResultObjectValidState()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleaArchMVC.Domain.Validations.DomainExceptionValidation>().WithMessage("ID inválido!");
        }
    }
}