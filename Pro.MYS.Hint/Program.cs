using Microsoft.Extensions.DependencyInjection;
using Pro.MYS.DataAccess;
using Pro.MYS.Application;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIOC(builder.Configuration);
builder.Services.AddAutoMapperConfig();
builder.Services.AddApplication();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllOrigins",
        builder =>
        {
            builder.AllowAnyHeader()
                           .AllowAnyOrigin()
                          .AllowAnyMethod();
        });
});

var app = builder.Build();
app.UseCors("AllOrigins");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
