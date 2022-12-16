using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using UserRegistration.Repository.Database;
using UserRegistration.Repository.Repository;
using UserRegistration.Service.Interfaces;
using UserRegistration.Service.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var services = builder.Services;

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*,http://127.0.0.1:5500").AllowAnyHeader().AllowAnyHeader())
);

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UserRegistration_API",
        Version = "v1"
    });
});

services.AddDbContext<userregistration_Context>(Options =>
{
    Options.UseSqlServer(
    builder.Configuration.GetConnectionString("userregistration_Context"),
    sqlServerOptions => sqlServerOptions.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
    );
});
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped(typeof(IRegisterService), typeof(RegisterService));


services.AddMvc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Userregistration.Api v1"));
}
app.UseAuthentication();

app.UseHttpsRedirection();

app.UseRouting();

//app.UseCors(options => options.AllowAnyOrigin());
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

