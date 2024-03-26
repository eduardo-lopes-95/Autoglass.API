using Autoglass.API.Shared.Requests;
using FluentValidation;

namespace Autoglass.API.Infra.Validators;

public class CreateProductRequestValidator : AbstractValidator<RequestCreateProductDto>
{
    public CreateProductRequestValidator()
    {
        RuleFor(request => request.DataFabricacao)
            .LessThan(req => req.DataValidade)
            .WithErrorCode("FabricationDateGreaterThanExpirationDate")
            .WithMessage("It's not possible to create product with fabrication date greater than expiration date");
    }
}
