using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Week4.Data.Abstract;
using Week4.Data.Concrete;
using Week4.Data.Context;
using Week4.Service.Abstract;
using Week4.Service.Concrete;
using Week4.Service.Mapping;

namespace Week4.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Week4.Api", Version = "v1" });
            });
            services.AddAutoMapper(typeof(MapProfile));

            services.AddDbContext<EFContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddTransient<IProductRepository, ProductRepository>();


            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Week4.Api v1"));
            }

            app.UseRouting();
            app.UseMiddleware<LogMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
public class LogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogMiddleware> _logger;

    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {

        var watch = Stopwatch.StartNew();

        await _next.Invoke(httpContext);
        watch.Stop();
        if (watch.ElapsedMilliseconds > 500)
        {
            _logger.LogWarning ("Duration:{duration}ms, Request path:{path},Request Method:{method}",
                watch.ElapsedMilliseconds, httpContext.Request.Path, httpContext.Request.Method);
        }
        else
        {
            _logger.LogInformation("Herþey yolunda");
        }
    }
}

