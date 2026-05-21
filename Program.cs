
using Microsoft.EntityFrameworkCore;
using Web_API_DAY2.MappingConfig;

namespace Web_API_DAY2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            //builder.Services.AddControllers().AddNewtonsoftJson(op=>op.SerializerSettings.ReferenceLoopHandling=
            //    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            //dbcontext register in DI
            builder.Services.AddDbContext<ItiContext>(options =>
            {
                options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddAutoMapper(op => op.AddProfile<MapConfig>());

            builder.Services.AddCors(
                op =>
                {
                    op.AddPolicy("txt",
                       builder =>
                       {
                           //builder.WithOrigins("https://localhost:7259");
                           builder.AllowAnyOrigin();
                           // builder.WithMethods("GET", "POST");
                           builder.AllowAnyMethod();
                           builder.AllowAnyHeader();
                       });
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                //Enabling swagger ui + launch setting "launchUrl": "Swagger"
                app.UseSwaggerUI(op=>op.SwaggerEndpoint("/openapi/v1.json","v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("txt");
            app.Run();
        }
    }
}
