using Demo.Application.config;
using Demo.Application.demo.ports.Out;
using Demo.Infrastructure.config;
using Demo.Infrastructure.ExternalServices;

var builder = WebApplication.CreateBuilder(args);

var discountApiUrl = builder.Configuration["ExternalServices:DiscountApiBaseUrl"];

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddMemoryCache();
builder.Services.AddInfrastructure();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.TagActionsBy(api => new[] { api.GroupName ?? api.ActionDescriptor.RouteValues["controller"] });

});

if (string.IsNullOrEmpty(discountApiUrl))
{
    throw new InvalidOperationException("La configuración 'ExternalServices:DiscountApiBaseUrl' no está definida.");
}

builder.Services.AddHttpClient<IDiscount, DiscountApiClient>(client =>
{
    client.BaseAddress = new Uri(discountApiUrl);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();