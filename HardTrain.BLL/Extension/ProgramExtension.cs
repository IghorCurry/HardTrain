using HardTrain.BLL.Contracts;
using HardTrain.BLL.Managers;
using HardTrain.DAL;
using Microsoft.Extensions.DependencyInjection;
using SharedModules.Application.Common.Abstractions;

namespace HardTrain.BLL.Extension;

public static class ProgramExtension
{
    //public static void AddAutoMapper(this IServiceCollection services)
    //{
    //    services.AddScoped<Profile, MappingProfiles>();
    //}

    public static void AddBllManagers(this IServiceCollection services)
    {
        services.AddScoped<IExersiceManager, ExersiceManager>();
        services.AddScoped<ITrainingManager, TrainingManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<ITrainingResultManager, TrainingResultManager>();
        services.AddScoped<IDataContext, DataContext>();
    }




    //public static void ConnectSwagger(this IServiceCollection services)
    //{
    //    services.AddSwaggerGen(options =>
    //    {
    //        options.SwaggerDoc("v1.0", new OpenApiInfo { Title = "HardTrain.Web", Version = "v1.0" });
    //        options.OperationFilter<RemoveVersionFromParameter>();
    //    });
    //}
}
