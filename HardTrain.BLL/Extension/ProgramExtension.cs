using Mapster.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardTrain.BLL.Contracts;
using HardTrain.BLL.Managers;
using Microsoft.OpenApi.Models;
using HardTrain.BLL.Helper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

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
    