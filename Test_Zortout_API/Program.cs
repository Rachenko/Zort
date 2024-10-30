using Test_Zortout_API.External;
using Test_Zortout_API.External.Interface;
using Test_Zortout_API.Helper.Interface;
using Test_Zortout_API.Helper;
using Test_Zortout_API.Services;
using Test_Zortout_API.Services.Interface;
using Test_Zortout_API.Entities.ZortExam;
using Microsoft.EntityFrameworkCore;
using Test_Zortout_API.Repositories.Interface;
using Test_Zortout_API.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddScoped<IZortApi, ZortApi>();
builder.Services.AddScoped<ITestServices, TestServices>();
builder.Services.AddScoped<ITestRepositories, TestRepositories>();
builder.Services.AddTransient<IAppSettingHelper, AppSettingHelper>();
builder.Services.AddDbContext<ZortExam_DbContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("ZortExam")));
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
