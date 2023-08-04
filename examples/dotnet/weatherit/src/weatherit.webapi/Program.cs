const string allowSpecificOriginsTag = "MyAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: allowSpecificOriginsTag,
    policy =>
    {
      policy
        // .WithOrigins("https://localhost:7255")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .DisallowCredentials()
        .AllowAnyHeader()
        .WithExposedHeaders("*");
      ;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(allowSpecificOriginsTag);

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
});

// app.UseAuthorization();

app.MapControllers();

app.Run();
