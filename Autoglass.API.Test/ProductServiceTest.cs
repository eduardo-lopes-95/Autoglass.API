using Autoglass.API.Domain.Core.Interfaces.Repositories;
using Autoglass.API.Domain.Core.Interfaces.Services;
using Autoglass.API.Domain.Models;
using Autoglass.API.Domain.Services.Services;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Autoglass.API.Shared.Responses;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Autoglass.API.Test;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly Mock<IUriService> _mockUriService;
    private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;

    public ProductServiceTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockUriService = new Mock<IUriService>();
        _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
    }

    [Fact]
    public async Task CreateProductAsync_PositiveCase_ReturnsBaseResponseWithoutErrors()
    {
        // Arrange
        var productService = new ProductService(
            _mockProductRepository.Object,
            _mockUriService.Object,
            _mockHttpContextAccessor.Object);

        var cancellationToken = new CancellationToken();

        var requestCreateProductDto = new RequestCreateProductDto
        {
            CodigoProduto = 12345,
            DescricaoProduto = "Produto A",
            SituacaoProduto = "Inativo",
            DataFabricacao = new DateTime(2024, 3, 1, 8, 30, 0),
            DataValidade = new DateTime(2024, 3, 26, 8, 30, 0),
            CodigoFornecedor = 9876,
            DescricaoFornecedor = "Fornecedor XYZ",
            CNPJFornecedor = "12345678000190",
        };


        _mockProductRepository.Setup(repo => repo.AddProduct(It.IsAny<Product>()));

        // Act
        var result = await productService.CreateProductAsync(requestCreateProductDto, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BaseResponse>(result);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public async Task CreateProductAsync_NegativeCase_ReturnsBaseResponseWithError()
    {
        // Arrange
        var productService = new ProductService(
            _mockProductRepository.Object,
            _mockUriService.Object,
            _mockHttpContextAccessor.Object);

        var cancellationToken = new CancellationToken();

        var requestCreateProductDto = new RequestCreateProductDto
        {
            CodigoProduto = 12345,
            DescricaoProduto = "Produto A",
            SituacaoProduto = "Inativo",
            DataFabricacao = DateTime.Parse("2024-03-30T08:30:00"),
            DataValidade = DateTime.Parse("2024-03-26T08:30:00"),
            CodigoFornecedor = 9876,
            DescricaoFornecedor = "Fornecedor XYZ",
            CNPJFornecedor = "12345678000190",
        };

       _mockProductRepository.Setup(repo => repo.AddProduct(It.IsAny<Product>()));

        // Act
        var result = await productService.CreateProductAsync(requestCreateProductDto, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BaseResponse>(result);
        Assert.NotEmpty(result.Errors);
    }

    [Fact]
    public async Task EditProductByIdAsync_PositiveCase_ReturnsBaseResponseWithUpdatedProduct()
    {
        // Arrange
        var productService = new ProductService(
            _mockProductRepository.Object,
            _mockUriService.Object,
            _mockHttpContextAccessor.Object);

        var cancellationToken = new CancellationToken();

        var id = 1;

        var dto = new RequestUpdateProductDto
        {
            DescricaoProduto = "Nova Descricao", 
            SituacaoProduto = "Ativo",
            DataFabricacao = DateTime.Parse("2024-03-20T08:30:00"),
            DataValidade = DateTime.Parse("2024-03-26T08:30:00")
        };

        var product = new Product 
        {
            Id = id,
            CodigoProduto = 12345,
            DescricaoProduto = "Produto A",
            SituacaoProduto = "Inativo",
            DataFabricacao = DateTime.Parse("2024-03-30T08:30:00"),
            DataValidade = DateTime.Parse("2024-03-26T08:30:00"),
            CodigoFornecedor = 9876,
            DescricaoFornecedor = "Fornecedor XYZ",
            CNPJFornecedor = "12345678000190",
        };

        _mockProductRepository.Setup(repo => repo.GetByIdProductAsync(id)).ReturnsAsync(product);
        _mockProductRepository.Setup(repo => repo.UpdateProduct(It.IsAny<Product>(), It.IsAny<string[]>()));

        // Act
        var result = await productService.EditProductByIdAsync(id, dto, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BaseResponse<ResponseReadProductDto>>(result);
        Assert.NotNull(result.Data);
        Assert.Equal(dto.DescricaoProduto, result.Data.DescricaoProduto);
        Assert.Equal(dto.SituacaoProduto, result.Data.SituacaoProduto);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public async Task EditProductByIdAsync_NegativeCase_ReturnsBaseResponseWithError()
    {
        // Arrange
        var productService = new ProductService(
            _mockProductRepository.Object,
            _mockUriService.Object,
            _mockHttpContextAccessor.Object);

        var cancellationToken = new CancellationToken();

        var id = 1; // Set a valid product ID for testing

        var dto = new RequestUpdateProductDto
        {
            DescricaoProduto = "Nova descricao", 
            SituacaoProduto = "Ativo"
        };

        var product = new Product { Id = id };

        _mockProductRepository.Setup(repo => repo.GetByIdProductAsync(id)).ReturnsAsync(product);
        _mockProductRepository.Setup(repo => repo.UpdateProduct(It.IsAny<Product>(), It.IsAny<string[]>()));

        // Act
        var result = await productService.EditProductByIdAsync(id, dto, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BaseResponse<ResponseReadProductDto>>(result);
        Assert.NotNull(result.Data);
        Assert.NotEmpty(result.Errors);
    }

    [Fact]
    public async Task DisableProductByIdAsync_PositiveCase_ReturnsBaseResponseWithDisabledProduct()
    {
        // Arrange
        var productService = new ProductService(
            _mockProductRepository.Object,
            _mockUriService.Object,
            _mockHttpContextAccessor.Object);

        var cancellationToken = new CancellationToken();

        var id = 1; // Set a valid product ID for testing

        var product = new Product { Id = id, SituacaoProduto = "Ativo" }; // Create a sample product object

        _mockProductRepository.Setup(repo => repo.GetByIdProductAsync(id)).ReturnsAsync(product);
        _mockProductRepository.Setup(repo => repo.RemoveProduct(It.IsAny<Product>(), It.IsAny<string>()));

        // Act
        var result = await productService.DisableProductByIdAsync(id, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BaseResponse<ResponseReadProductDto>>(result);
        Assert.NotNull(result.Data);
        Assert.Equal("Inativo", result.Data.SituacaoProduto);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public async Task DisableProductByIdAsync_NegativeCase_ReturnsBaseResponseWithError()
    {
        // Arrange
        var productService = new ProductService(
            _mockProductRepository.Object,
            _mockUriService.Object,
            _mockHttpContextAccessor.Object);

        var cancellationToken = new CancellationToken();

        var id = 1; // Set a valid product ID for testing

        _mockProductRepository.Setup(repo => repo.GetByIdProductAsync(id));

        // Act
        var result = await productService.DisableProductByIdAsync(id, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<BaseResponse<ResponseReadProductDto>>(result);
        Assert.NotNull(result.Errors);
        Assert.NotEmpty(result.Errors);
    }
}
