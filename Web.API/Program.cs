using UoW.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var companiesConnectionString = builder.Configuration.GetConnectionString("CompaniesConnection");
var organizationsConnectionString = builder.Configuration.GetConnectionString("OrganizationsConnection");

builder.Services.AddCompaniesRepositories(companiesConnectionString);
builder.Services.AddOrganizationsRepositories(organizationsConnectionString);

builder.Services.AddLogic();

var app = builder.Build();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseSwagger(s => s.SerializeAsV2 = true);

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.MapControllers();

app.Run();
