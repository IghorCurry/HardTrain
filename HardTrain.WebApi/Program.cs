using HardTrain.BLL.Extension;
using HardTrain.DAL;
using HardTrain.DAL.Entities.UserResultScope;
using Microsoft.EntityFrameworkCore;
using SharedModules.Infrastructure.Identity.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddBllManagers();
//builder.Services.ConnectSwagger();
builder.Services.AddDbContext<DataContext>(opts =>
                opts.UseSqlServer(builder.Configuration["ConnectionStrings:HardTrainDatabaseConnection"]));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityConfiguration<DataContext, User, Role>()
            .AddIdentityCoreModelsValidators()
            .AddIdentityCoreServices<User>()
            .AddJwtTokenConfiguration(builder.Configuration)
            .MapEmailToUserName()
            .AddPolicies(options =>
            {
                options.AddPolicy("RequireAdmin", policy =>
                    policy.RequireRole("Admin"));
                options.AddPolicy("RequireStudent", policy =>
                    policy.RequireRole("Student"));
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

