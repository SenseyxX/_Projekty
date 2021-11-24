using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Mag
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mag.Api", Version = "v1" });
            });
            services
                        .AddTransient<ICategoryRepository, CategoryRepository>()
                        .AddTransient<IItemRepository, ItemRepository>()
                        .AddTransient<IItemService, ItemService>()
                        .AddTransient<ILoanHistoryRepository, LoanHistoryRepository>()
                        .AddTransient<IQualityRepository, QualityRepository>()
                        .AddTransient<ISquadRepository, SquadRepository>()
                        .AddTransient<IUserRepository, UserRepository>()
                        .AddTransient<IUserService, UserService>();

            services.AddDbContext<MagContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddControllers().AddFluentValidation();
            services
                    .AddScoped<QualitySeeder>()
                    .AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, QualitySeeder seeder)
        {
            seeder.Seed();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mag.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
