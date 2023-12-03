var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

builder.Services.AddCustomServices();
builder.Services.AddCustomDbContext(builder.Configuration);
builder.Services.AddCustomJWT(builder.Configuration);
builder.Services.AddCustomMvc();
builder.Services.AddSwagger();


var app = builder.Build();

app.UseCustomSwagger();
app.UseCustomMiddleware();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
