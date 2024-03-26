using Autoglass.API.Infra.Filter;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace Autoglass.API.Infra.Extensions;

public static class ValidationMvcExtension
{
    public static IMvcBuilder AddValidationControllers(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        mvcBuilder.AddMvcOptions(options => {
            options.Filters.Add<ValidateModelStateFilter>();
        });
        mvcBuilder.AddFluentValidation(fv => {
            fv.DisableDataAnnotationsValidation = true;
            ConfigureValidators.RegisterValidators(fv);
        });
        return mvcBuilder;
    }
}
