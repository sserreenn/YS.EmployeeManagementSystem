using EMS.Api.Extensions;
using EMS.Core.Extensions;
using EMS.Domains.EntityFramework.Application;
using EMS.Domains.EntityFramework.Business;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) => {
        config
            .SetBasePath(Directory.GetParent(typeof(Program).Assembly.Location)?.FullName)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() ?? "development"}.json", optional: false, true)
            .AddEnvironmentVariables();
    });
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() ?? "development";

// Controllers
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddEMSContext(builder.Configuration);
builder.Services.AddEntityFrameworkMediatr(builder.Configuration);
// Response Compression
builder.Services.Configure<GzipCompressionProviderOptions>(options => { options.Level = CompressionLevel.Fastest; });
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});
// Cors
builder.Services.AddCors();


// Swaggger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Petroo Anttech Charge Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "enter the request header in the following box and add JWT authorization token: Bear token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"}
            },Array.Empty<string>()
        }
    });
    c.OperationFilter<SwaggerDefaultValues>();
    var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
    c.IncludeXmlComments(filePath);
});

builder.Host.UseDefaultServiceProvider(options => options.ValidateScopes = false);

var app = builder.Build();


if (builder.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();


app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());
app.UseRouting();
 
//global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseStaticFiles();

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.DefaultModelsExpandDepth(-1);
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Petroo Anttech Charge Api v1");
});

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
