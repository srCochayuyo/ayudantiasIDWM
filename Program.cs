using ayudantis1.src.Data;
using ayudantis1.src.Interface;
using ayudantis1.src.Repository;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductsRepository, ProductRepository>();

string connectionString = Environment.GetEnvironmentVariable("DATABASE_URL") ?? "Data Source=app.db"; //True, false
builder.Services.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();

//Seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDBContext>();
    DataSeeder.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
