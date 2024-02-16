using ManagementSystem.Business.Repositories;
using ManagementSystem.Business.Repositories.Interfaces;
using ManagementSystem.Business.Services.Employees;
using ManagementSystem.Business.Translators.Employees;
using ManagementSystem.Business.Utility.Employee;
using ManagementSystem.Business.Utility.Interfaces.Employee;
using ManagementSystem.WebApi.Controllers;

namespace ManagementSystem.WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMvc();

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<EmployeeController>>();
            services.AddSingleton(typeof(ILogger), logger);

            string? connectionString = Configuration.GetConnectionString("ManagementSystemDatabase");

            var employeeRepository = new EmployeeRepository(connectionString);
            services.AddSingleton<IEmployeeRepository>(employeeRepository);

            ConfigureDependencyInjection(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IEmployeeDbClientFactory, EmployeeDbClientFactory>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeTranslator, EmployeeTranslator>();
        }
    }
}
