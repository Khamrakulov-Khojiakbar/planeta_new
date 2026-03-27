using Planeta_New.Extensions;
using Planeta.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSwaggerExtension();


var app = builder.Build();


app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerExtension();



app.Run();