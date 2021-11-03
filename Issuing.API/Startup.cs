using FluentValidation;
using Issuing.Application.Dto.Card;
using Issuing.Application.DtoMappings;
using Issuing.Application.Interfaces;
using Issuing.Application.Services.Cards;
using Issuing.Application.Validations.Card;
using Issuing.Domain.Interfaces;
using Issuing.Domain.Interfaces.Repos;
using Issuing.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Issuing.API
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
            services.AddHealthChecks();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Issuing.API", Version = "v1" });
            });

            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"), serverOptions => serverOptions.MigrationsAssembly(typeof(StoreContext).Assembly.FullName));
            });

            services.AddAutoMapper(typeof(CardMappingProfiles).Assembly);
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IValidator<CardCreateRequest>, CardCreateRequestValidator>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Issuing.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");
                endpoints.MapControllers();
            });
        }
    }
}
