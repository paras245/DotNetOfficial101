using ConstosoCrafts.Websites.Models;
using ConstosoCrafts.Websites.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    //endpoints.MapGet("/products", async context =>
    //{
    //    // Resolve the service using the built-in DI container
    //    var productService = context.RequestServices.GetRequiredService<JsonFileProductService>();

    //    // Retrieve the products
    //    var products = productService.GetProducts();

    //    // Serialize the products to JSON
    //    var json = JsonSerializer.Serialize(products);

    //    // Set the content type to JSON
    //    context.Response.ContentType = "application/json";

    //    // Write the JSON to the response stream
    //    await context.Response.WriteAsync(json);
    //});
});


app.Run();
