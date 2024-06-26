﻿using Autoglass.API.Domain.Core.Interfaces.Repositories;
using Autoglass.API.Domain.Core.Interfaces.Services;
using Autoglass.API.Infra.Filter;
using Autoglass.API.Infra.Helper;
using Autoglass.API.Infra.Validators;
using Autoglass.API.Shared.Base;
using Autoglass.API.Shared.Requests;
using Autoglass.API.Shared.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Autoglass.API.Domain.Services.Services;

public class ProductService : IProductService
{
    private IProductRepository ProductRepository;
    private IUriService UriService;
    private IHttpContextAccessor HttpContextAccessor;

    public ProductService(IProductRepository productRepository, IUriService uriService, IHttpContextAccessor httpContextAccessor)
    {
        ProductRepository = productRepository;
        UriService = uriService;
        HttpContextAccessor = httpContextAccessor;
    }

    public async Task<BasePagedResponse<IEnumerable<ResponseReadProductDto>>> GetAllProductsAsync(PaginationFilter filter, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var route = GetCurrentUrl(HttpContextAccessor.HttpContext.Request);

        var products = await ProductRepository.GetAllProductsAsync();

        var productList = PaginationHelper.PagedData(filter, products);

        var response = productList.Select(p => new ResponseReadProductDto().MapToDto(p));

        var pagedResponse = PaginationHelper.CreatePagedReponse(response, filter, productList.Count(), UriService, route);

        return pagedResponse;
    }

    public async Task<BaseResponse> CreateProductAsync(RequestCreateProductDto dto, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var validation = await new CreateProductRequestValidator().ValidateAsync(dto, cancellationToken);

        if(!validation.IsValid)
        {
            return new BaseResponse
            {
                Errors = validation.Errors.Select(e => new BaseResponseError 
                {
                    ErrorCode = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToList()
            };
        }

        var product = dto.MapToEntity(dto);
         
        await ProductRepository.AddProduct(product);

        return new BaseResponse
        {
            Errors = new List<BaseResponseError>(),
        };
    }

    public async Task<BaseResponse<ResponseReadProductDto>> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var product = await ProductRepository.GetByIdProductAsync(id);

        if(product is null)
        {
            return new BaseResponse<ResponseReadProductDto>
            {
                Data = new ResponseReadProductDto(),
                Errors = new List<BaseResponseError>()
                {
                    new BaseResponseError
                    {
                        ErrorCode = "ProductNotFound",
                        Message = "Product not found"
                    }   
                },
            };
        }

        var dto = new ResponseReadProductDto().MapToDto(product);

        return new BaseResponse<ResponseReadProductDto>
        {
            Data = dto,
            Errors = new List<BaseResponseError>(),
        };
    }

    public async Task<BaseResponse<ResponseReadProductDto>> EditProductByIdAsync(int id, RequestUpdateProductDto dto, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var validation = await new UpdateProductRequestValidator().ValidateAsync(dto, cancellationToken);

        if (!validation.IsValid)
        {
            return new BaseResponse<ResponseReadProductDto>
            {
                Data = new ResponseReadProductDto(),
                Errors = validation.Errors.Select(e => new BaseResponseError
                {
                    ErrorCode = e.ErrorCode,
                    Message = e.ErrorMessage
                }).ToList()
            };
        }

        var foundProduct = await ProductRepository.GetByIdProductAsync(id);

        if (foundProduct is null)
        {
            return new BaseResponse<ResponseReadProductDto>
            {
                Data = new ResponseReadProductDto(),
                Errors = new List<BaseResponseError>()
                {
                    new BaseResponseError()
                    {
                        ErrorCode = "ProductNotFound",
                        Message = $"Product with Code {id} not found"
                    }
                },
            };
        }

        foundProduct.DescricaoProduto = dto.DescricaoProduto;
        foundProduct.SituacaoProduto = dto.SituacaoProduto;

        await ProductRepository.UpdateProduct(foundProduct, ["DescricaoProduto", "SituacaoProduto"]);

        var product = await ProductRepository.GetByIdProductAsync(id);

        var response = new ResponseReadProductDto().MapToDto(product);

        return new BaseResponse<ResponseReadProductDto>
        {
            Data = response,
            Errors = new List<BaseResponseError>(),
        };
    }

    public async Task<BaseResponse<ResponseReadProductDto>> DisableProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var foundProduct = await ProductRepository.GetByIdProductAsync(id);

        if (foundProduct is null)
        {
            return new BaseResponse<ResponseReadProductDto>
            {
                Data = new ResponseReadProductDto(),
                Errors = new List<BaseResponseError>()
                {
                    new BaseResponseError()
                    {
                        ErrorCode = "ProductNotFound",
                        Message = $"Product with Code {id} not found"
                    }
                },
            };
        }

        foundProduct.SituacaoProduto = "Inativo";

        await ProductRepository.RemoveProduct(foundProduct, "SituacaoProduto");

        var product = await ProductRepository.GetByIdProductAsync(id);

        var response = new ResponseReadProductDto().MapToDto(product);

        return new BaseResponse<ResponseReadProductDto>
        {
            Data = response,
            Errors = new List<BaseResponseError>(),
        };
    }

    private string GetCurrentUrl(HttpRequest request)
    {
        return request.Path + request.QueryString;
    }
}
