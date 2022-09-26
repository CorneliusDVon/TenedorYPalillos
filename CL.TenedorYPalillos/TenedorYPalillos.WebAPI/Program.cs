using MediatR;
using System.Reflection;
using TenedorYPalillos.BaseController;


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

            //AGREGA UN DBCONTEXT EN CASO DE USO DE HANDLERS
            //builder.Services.AddDbContext<RestoContext>();


            //CONGIFURACION DE SWAGGER/OpenAPI [https://aka.ms/aspnetcore/swashbuckle]
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();


            //CONFIGURAR AMBIENTE DE SOLICITUDES HTTP.
            if (app.Environment.IsDevelopment())
            {                
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
