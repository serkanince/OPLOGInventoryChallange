using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OPLOGInventory.Application;
using OPLOGInventory.Application.ApiUsers;
using OPLOGInventory.Application.Containers;
using OPLOGInventory.Application.InventoryItems;
using OPLOGInventory.Application.Products;
using OPLOGInventory.Application.QueryApplications;
using OPLOGInventory.Application.SalesOrders;
using OPLOGInventory.Infrastructure.DB;
using OPLOGInventory.Infrastructure.UOW;
using OPLOGInventory.Repository.ApiUser;
using OPLOGInventory.Repository.Container;
using OPLOGInventory.Repository.InventoryItem;
using OPLOGInventory.Repository.Location;
using OPLOGInventory.Repository.Product;
using OPLOGInventory.Repository.SalesOrder;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace OPLOGInventory.API
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


            services.AddDbContext<MSSQLDBContext>(options => options.UseLazyLoadingProxies()

            //PROD
            //.UseSqlServer("Server=amazonpandifdb.cqvgxnec4fgu.us-east-2.rds.amazonaws.com;Initial Catalog=Pandif;Persist Security Info=False;User ID=pandifdb;Password=E_3p1n9m;Connection Timeout=30;"));

            //TEST
            .UseSqlServer("Server=.\\SQLEXPRESS; Database=OPLOGInventory; Trusted_Connection=True;"));


            //INJECT//
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MSSQLDBContext>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<ISalesOrderApplication, SalesOrderApplication>();
            services.AddTransient<IInventoryItemApplication, InventoryItemApplication>();
            services.AddTransient<IApiUserApplication, ApiUserApplication>();
            services.AddTransient<IContainerApplication, ContainerApplication>();
            services.AddTransient<IQueryApplication, QueryApplication>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISalesOrderRepository, SalesOrderRepository>();
            services.AddTransient<IContainerRepository, ContainerRepository>();
            services.AddTransient<IInventoryItemRepository, InventoryItemRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IApiUserRepository, ApiUserRepository>();

            //INJECT//


            // OPEN API
            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OPLOG Inventory API",
                    Contact = new OpenApiContact
                    {
                        Name = "Serkan Ince",
                        Email = "serkanince444@gmail.com",
                        Url = new Uri("https://dev.serkanince.com"),
                    },
                });
                c.EnableAnnotations(); //custom attribute enable

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //

            //AUTOMAPPER 
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            //AUTOMAPPER




            //JWT

            var key = Encoding.ASCII.GetBytes(Configuration["Application:Secret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })


            .AddJwtBearer(x =>
            {

                x.Audience = "OPLOG";
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.ClaimsIssuer = "OPLOG.Issuer.Prod";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = true
                };
            });

            //JWT


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OPLOG Inventory API V1");
            });

        }
    }
}
