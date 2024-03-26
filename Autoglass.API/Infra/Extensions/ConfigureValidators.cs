using Autoglass.API.Infra.Validators;
using FluentValidation.AspNetCore;

namespace Autoglass.API.Infra.Extensions;

public static class ConfigureValidators
{
    public static FluentValidationMvcConfiguration RegisterValidators(FluentValidationMvcConfiguration fv)
    {
        fv.RegisterValidatorsFromAssemblyContaining<CreateProductRequestValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<UpdateProductRequestValidator>();
        return fv;
    }
}
