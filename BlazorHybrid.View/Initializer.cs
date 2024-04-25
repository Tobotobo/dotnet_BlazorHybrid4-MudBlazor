using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace BlazorHybrid.View
{
    public static class Initializer
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddMudServices();
        }
    }
}