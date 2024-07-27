using Pingo.Abstraction.Interfaces;
using Pingo.DataAccess;
using Pingo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read the connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register repositories with the connection string
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(provider =>
{
    return new UnitOfWork(
        connectionString,
        new ClientRepository(connectionString),
        new AddressRepository(connectionString),
        new ContactRepository(connectionString)
    );
});

// Register services
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS to allow any origin, method, and header
app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
