using GraphQL.Example.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InfrastructureRegister();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.Services.InfrastructureStartup();
var swaggerFile = string.Concat(app.Configuration["ROUTE_PREFIX"], "/swagger/v1/swagger.json");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(opt => { opt.SwaggerEndpoint(swaggerFile, "Graphql Example Development"); });
}

app.UseHttpsRedirection();
app.UsePathBase(app.Configuration["ROUTE_PREFIX"]);
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    app.InfrastructureBuilder(endpoints, app.Configuration);

});
app.UseSwagger();
app.UseSwaggerUI(cfg =>
{
    cfg.SwaggerEndpoint(swaggerFile, "Graphql Example");
});
app.MapControllers();

app.Run();
