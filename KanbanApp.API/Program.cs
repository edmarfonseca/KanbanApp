using KanbanApp.API.Configurations;
using KanbanApp.Domain.Interfaces.Repositories;
using KanbanApp.Domain.Interfaces.Services;
using KanbanApp.Domain.Services;
using KanbanApp.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
CorsConfiguration.AddCorsConfiguration(builder.Services);
DependencyInjectionConfiguration.AddDependencyInjection(builder.Services);
MongoDBConfiguration.AddMongoDBConfiguration();
JwtBearerConfiguration.AddJwtSecurity(builder.Services);

var app = builder.Build();

SwaggerConfiguration.UseSwaggerConfiguration(app);
CorsConfiguration.UseCorsConfiguration(app);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
