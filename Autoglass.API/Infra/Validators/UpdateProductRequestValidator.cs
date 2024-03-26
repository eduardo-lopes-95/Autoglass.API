using Autoglass.API.Shared.Requests;
using FluentValidation;

namespace Autoglass.API.Infra.Validators;

public class UpdateProductRequestValidator : AbstractValidator<RequestUpdateProductDto>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(request => request.DataFabricacao)
            .LessThan(req => req.DataValidade)
            .WithErrorCode("FabricationDateGreaterThanExpirationDate")
            .WithMessage("It's not possible to update product with fabrication date greater than expiration date");
    }
}
