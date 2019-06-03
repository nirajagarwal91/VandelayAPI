using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using VandelayWebAPI.Entities;
using VandelayWebAPI.Services;

namespace VandelayWebAPI
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
            services.AddMvc(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connectionString = Configuration["connectionStrings:vandelayDBConnectionString"];
            //services.AddDbContext<FactoryContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<FactoryContext>(options => options.UseInMemoryDatabase("vandelayDB"));
            //registering the repository
            services.AddScoped<IFactoryRepository, FactoryRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Vandelay API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FactoryContext factoryContext)
        {
            //app.UseStaticFiles();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vandelay API v1");
                });
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected error has occured. Try again Later.");
                    });
                });
            }

            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vandelay API v1");
            //});
            //app.UseHttpsRedirection();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Factory, Models.FactoryDto>();
                    //.ForMember(dest => dest.FactoryAddress,
                    //    opt => opt.MapFrom(src =>
                    //        $"{src.FactoryAddress.BuildingName}, {src.FactoryAddress.StreetLine1}, {src.FactoryAddress.StreetLine2}, {src.FactoryAddress.City}, {src.FactoryAddress.StateProvince}, {src.FactoryAddress.ZipPostalCode}, {src.FactoryAddress.Country}"));
                cfg.CreateMap<Entities.Machine, Models.MachineDto>();
            });
            factoryContext.SeedDataForFactoryContext();
            app.UseMvc();
        }
    }
}
