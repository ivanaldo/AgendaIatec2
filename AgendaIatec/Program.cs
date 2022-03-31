using AgendaIatec.Context;
using AgendaIatec.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Contexto>(
    options => options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=AgendaIatec;Integrated Security=True;")
    );

builder.Services.AddControllers();
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

app.MapPost("/", () => {
    var usuraios = new UsuariosController();
    usuraios.PostAsync();
});

app.Run();
