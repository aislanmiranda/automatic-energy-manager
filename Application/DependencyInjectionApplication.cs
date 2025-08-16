using System.Reflection;
using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

public static class DependencyInjectionApplication
{
    public static void AddApplication(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddHttpContextAccessor(); //para pegar informacoes do token
        services.AddTransient<ICustomerApplication, CustomerApplication>();
        services.AddTransient<IUserApplication, UserApplication>();
        services.AddTransient<IEquipamentApplication, EquipamentApplication>();
        services.AddTransient<ITaskApplication, TaskApplication>();

        string HangFireConn = Environment.GetEnvironmentVariable("HFHOST")!;
        string HasSSL = Environment.GetEnvironmentVariable("HFHOSTSSL")!;

        string prefix = HasSSL.Equals("false") ? "http" : "https";
        #if DEBUG
        HangFireConn = configuration.GetConnectionString("HangFireConn")!;
        #endif
        services.AddRefitClient<IHangFireApplication>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{prefix}://{HangFireConn}"));
    }
}