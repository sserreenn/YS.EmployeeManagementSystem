using EMS.Domains.EntityFramework.Business.Extensions;
using EMS.Domains.EntityFramework.Business.Settings;
using EMS.Domains.EntityFramework.Entity.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EMS.Domains.EntityFramework.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddEMSContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        // Context Settings Dependency
        var section = configuration.GetSection("ConnectionStrings");
        services.Configure<ContextSettings>(c => section.Bind(c));
        services.AddSingleton<IContextSettings>(sp => sp.GetRequiredService<IOptions<ContextSettings>>().Value);
        services.AddDbContext<EMSContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                conf => {
                    conf.MigrationsAssembly(typeof(EMSContext).Assembly.FullName);
                    conf.UseHierarchyId();
                }), ServiceLifetime.Transient);
        services.AddTransient<IUnitOfWork, HttpUnitOfWork>();
        return services;
    }
}