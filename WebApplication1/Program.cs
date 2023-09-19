using Microsoft.AspNetCore.Rewrite;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseRewriter(new RewriteOptions().AddRedirect("^$", "/drinks"));

app.UseCustomExceptionHandling();

app.Run();