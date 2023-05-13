using Microsoft.OpenApi.Models;
using SoportaAI.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "SoportaAI",
		Description = "An AI companion. Powered by OpenAI.",
		Contact = new OpenApiContact
		{
			Name = "Pavel Antropov",
			Url = new Uri("https://www.linkedin.com/in/pavelantropov/")
		},
	});
});

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(
		b =>
		{
			b.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});
//builder.Services.AddDbContext<ChatContext>(options => options.UseInMemoryDatabase("chat"));
builder.Services.AddMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("./swagger/v1/swagger.json", "SoportaAI");
		options.RoutePrefix = string.Empty;
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();