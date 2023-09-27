using Ecommerce.Application.Configuraitons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options => options.AddPolicy("ProductApp", policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    //policy.AllowAnyOrigin();
    policy.WithOrigins("http://localhost:4200");
}));

DependencyConfigurations.Configure(builder.Services);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ProductApp");

app.UseAuthorization();
app.MapControllers();

app.Run();
