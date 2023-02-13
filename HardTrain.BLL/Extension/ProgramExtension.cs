using HardTrain.BLL.Abstractions;
using HardTrain.BLL.Managers;
using HardTrain.BLL.Services;
using HardTrain.DAL;
using HardTrain.DAL.Setting;
using Microsoft.Extensions.Configuration;
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
        services.AddScoped<ICommentManager, CommentManager>();
        services.AddScoped<IPostManager, PostManager>();
        services.AddScoped<IUserIdentifierService, UserIdentifierService>();
    }

    public static IServiceCollection ConfigureSettingsModels(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<DefaultAdminSettings>(configuration.GetSection(nameof(DefaultAdminSettings)));





    //public static void ConnectSwagger(this IServiceCollection services)
    //{
    //    services.AddSwaggerGen(options =>
    //    {
    //        options.SwaggerDoc("v1.0", new OpenApiInfo { Title = "HardTrain.Web", Version = "v1.0" });
    //        options.OperationFilter<RemoveVersionFromParameter>();
    //    });
    //}
}
