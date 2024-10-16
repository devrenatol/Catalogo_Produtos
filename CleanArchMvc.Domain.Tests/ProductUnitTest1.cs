using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests;

public class ProductUnitTest1
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid Id value");
    }

    [Fact]
    public void CreateProduct_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid name, too short, minimum 3 charecters");
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoDomainException()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
        action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithNullImageName_NoNullReferenceExceptio()
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
        action.Should().NotThrow<NullReferenceException>();
    }

    public void CreateProduct_InvalidStockValue_DomainExceptionNagativeValue(int value)
    {
        Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, value, "Product Image");
        action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
              .WithMessage("Invalid stock value");
    }
}
