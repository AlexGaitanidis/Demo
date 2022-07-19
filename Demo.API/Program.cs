using Demo.API;
using Demo.Application.Queries;
using Demo.Domain.Repositories;
using Demo.Infrastructure.DataAccess;
using Demo.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UsersContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddMediatR(typeof(GetUsersQuery).Assembly);
builder.Services.AddAutoMapper(typeof(GetUsersQuery).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo.API V1");
        c.UseRequestInterceptor("(req) => { req.headers['authorization'] = 'apikeytest1'; return req; }");
    });
}

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var result = JsonConvert.SerializeObject(new { error = exception.Message });
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(result);
}));

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7177", "https://localhost:7177")
        .AllowAnyMethod()
        .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<AuthenticationToken>();

app.MapControllers();

app.Run();
