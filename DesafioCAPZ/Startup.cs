using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace DesafioCAPZ
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("AllowSpecificOrigin");

        }
    }
}

