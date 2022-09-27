using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Connection;
using TenedorYPalillos.Connection.Context;
using TenedorYPalillos.Model.DAO.UsuarioEntity;


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
            builder.Services.AddMediatR(typeof(LoginController).Assembly);
            builder.Services.AddMediatR(typeof(RestoController).Assembly);
            //builder.Services.AddMediatR(typeof(RestoDTORequest));
            //builder.Services.AddOptions();


            //REGISTRA EL CONTEXTO DE LA BASE DE DATOS
            builder.Services.AddDbContext<TenedorYPalillosContext>();


            //REGISTRA IDENTITY USER
            IdentityBuilder identityBuilder = builder.Services.AddIdentityCore<UsuarioEntityDAO>();
            IdentityBuilder identity = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);
            identity.AddEntityFrameworkStores<TenedorYPalillosContext>();
            identity.AddSignInManager<SignInManager<UsuarioEntityDAO>>();
            builder.Services.TryAddSingleton<ISystemClock, SystemClock>();


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

                UserManager<UsuarioEntityDAO> userManager = serices.GetRequiredService<UserManager<UsuarioEntityDAO>>();
                TenedorYPalillosContext context = serices.GetRequiredService<TenedorYPalillosContext>();

                //GENERA EL MODELO DE DATOS A  NIVEL DE DB
                context.Database.Migrate();
                
                //GENERA E INSERTA USUARIO ROOT AL CONTEXTO DE LA BASE DE DATOS
                ROOT.CreaUsuarioROOT(context,userManager).Wait();

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
