using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Connection.Context;


namespace TenedorYPalillos.WebAPI
{

    public class Program
    {

        public static void Main(string[] args)
        {

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


            //AGREGA CONTROLADORAS/APIS/SERVICIOS AL CONTENEDOR.
            builder.Services.AddControllers();


            //REGISTRO DE MEDIATR
            builder.Services.AddMediatR(typeof(RestoController).GetTypeInfo().Assembly);
            //builder.Services.AddMediatR(typeof(RestoDTORequest));
            //builder.Services.AddOptions();


            //REGISTRA EL CONTEXTO DE LA BASE DE DATOS
            builder.Services.AddDbContext<TenedorYPalillosContext>();


            //CONGIFURACION DE SWAGGER/OpenAPI [https://aka.ms/aspnetcore/swashbuckle]
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            WebApplication app = builder.Build();


            //GENERA LAS TABLAS EN LA BASE DE DATOS SEGUN EL MODELO DE DATOS
            using (IServiceScope enviroment = app.Services.CreateScope())
            {

                //USAR COMANDO PARA CREAR ARCHIVOS DE MIGRACION USANDO DBCONTEXT
                //PS D:\DESARROLLO\.NET CORE\GITHUB\repository\TenedorYPalillos\CL.TenedorYPalillos\TenedorYPalillos.Connection> dotnet ef --startup-project ../TenedorYPalillos.Connection migrations add TenedorYPalillosInicial -c TenedorYPalillosContext

                IServiceProvider serices = enviroment.ServiceProvider;

                TenedorYPalillosContext context = serices.GetRequiredService<TenedorYPalillosContext>();
                context.Database.Migrate();

            }


            //CONFIGURAR AMBIENTE DE SOLICITUDES HTTP.
            if (app.Environment.IsDevelopment())
            {           
                
                //SWAGGER
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseSwaggerUI(options =>
                //{
                //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                //    options.RoutePrefix = string.Empty;
                //});

            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }


    }
}
