using MiamBurger_API.Context;
using MiamBurger_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//On doit enregistrer les services et les context que l'on va injecter dans nos classes (injecter = recevoir dans constructeur)
builder.Services.AddSqlServer<MiamBurgerContext>("Server=DESKTOP-B5PORF8;Database=MiamBurgerDB;User Id=dotnet;Password=6ed87b347b;TrustServerCertificate=true");
builder.Services.AddScoped<BurgerService>();
builder.Services.AddScoped<UserService>();

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
