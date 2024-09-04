using NARA20240903;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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



// Registros Guardados:
List<Producto> Lista_Productos = new List<Producto>();


// ******* Endponit De La API ********

// GET : Obtener Todos Los Registros:
app.MapGet("/Producto", () =>
{
    return Lista_Productos;
});


