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


// GET : Obtener Un Registro Con Ese ID:
app.MapGet("/Producto/{id}", (int id) =>
{
    Producto Objeto_Obtenido = Lista_Productos.FirstOrDefault(x => x.IdProducto == id);
    return Objeto_Obtenido;
});


// POST : Recibe Un Objeto Y Lo Guarda En La Lista:
app.MapPost("/Producto", (Producto producto) =>
{
    Lista_Productos.Add(producto);
    return Results.Ok();
});


// PUT : Obtiene un Objeto con ese ID:
app.MapPut("/Producto/{id}", (int id, Producto producto) =>
{
    //Buscamos:
    Producto Objeto_Obtenido = Lista_Productos.FirstOrDefault(x => x.IdProducto == id);

    if (Objeto_Obtenido != null)
    {
        //Actualizamos Datos:
        Objeto_Obtenido.Nombre = producto.Nombre;
        Objeto_Obtenido.Precio = producto.Precio;
        Objeto_Obtenido.Marca = producto.Marca;

        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

