using HardTrain.BLL.Extension;
using HardTrain.DAL;
using HardTrain.DAL.Entities.UserResultScope;
using HardTrain.WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SharedModules.Infrastructure.Identity.Extensions;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddBllManagers();
builder.Services.ConfigureSettingsModels(builder.Configuration);
builder.Services.AddDbContext<DataContext>(opts =>
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:HardTrainDatabaseConnection"]));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentityConfiguration<DataContext, User, Role>()
            .AddIdentityCoreModelsValidators()
            .AddIdentityCoreServices<User>()
            .AddJwtTokenConfiguration(builder.Configuration)
            .MapEmailToUserName();
            //.AddPolicies(options =>
            //{
            //    options.AddPolicy("RequireAdmin", policy =>
            //        policy.RequireRole("Admin"));
            //    options.AddPolicy("RequireClient", policy =>
            //        policy.RequireRole("Client"));
            //    //options.AddPolicy("RequireManager", policy =>
            //    //    policy.RequireRole("Manager"));
            //});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireManager", policy =>
    {
        policy.RequireRole("Manager");
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
    });
});

#region Add Swagger

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1.0", new OpenApiInfo { Title = "HardTrain.WebAPI", Version = "v1.0" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,
            },
            new List<string>()
          }
        });
});

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "CustomerService.Core.WebApp");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });

}

app.UseHttpsRedirection();

app.UseStaticFiles();

//app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<UserIdentifierMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapControllers().RequireAuthorization();
}
else
{
    app.MapControllers().RequireAuthorization();
}

app.Run();