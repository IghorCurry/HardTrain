using AutoMapper;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Helper;
using HardTrain.BLL.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace HardTrain.BLL.Extension;

public static class ProgramExtension
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddScoped<Profile, MappingProfiles>();
    }

    public static void AddBllManagers(this IServiceCollection services)
    {
        services.AddScoped<IExersiceManager, ExersiceManager>();
        services.AddScoped<ITrainingManager, TrainingManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITrainingResultManager, TrainingResultManager>();
    }

    //public static void AddAuthorization(this IServiceCollection services)
    //{
    //    services.AddAuthorization(options =>
    //    {
    //        options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
    //            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
    //            .RequireAuthenticatedUser()
    //            .Build();
    //    });
    //}


    //public static void ConnectSwagger(this IServiceCollection services)
    //{
    //    services.AddSwaggerGen(options =>
    //    {
    //        options.SwaggerDoc("v1.0", new OpenApiInfo { Title = "HardTrain.Web", Version = "v1.0" });
    //        options.OperationFilter<RemoveVersionFromParameter>();
    //    });
    //}
}
