using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseFileServer(new FileServerOptions
{
    EnableDirectoryBrowsing = true,
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = new PathString("")
});

app.Run();