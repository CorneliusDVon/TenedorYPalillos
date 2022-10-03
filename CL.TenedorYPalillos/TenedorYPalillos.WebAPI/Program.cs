using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Connection;
using TenedorYPalillos.Connection.Context;
using TenedorYPalillos.Model.Contract.Security;
using TenedorYPalillos.Model.Contract.SessionUsuario;
using TenedorYPalillos.Model.DAO.UsuarioEntity;
using TenedorYPalillos.Model.Security;


namespace TenedorYPalillos.WebAPI
{

    public class Program
    {

        public static void Main(string[] args)
        {

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


            //AGREGA CONTROLADORAS/APIS/SERVICIOS AL CONTENEDOR.
            builder.Services.AddControllers(opt => 
            {
                //SE AGREGA SEGMENTO PARA SOLICITAR AUTENTICACION ANTES DE UTILIZAR LOS RECURSOS DE LA API
                AuthorizationPolicy policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            });


            //REGISTRO DE MEDIATR
            builder.Services.AddMediatR(typeof(LoginController).Assembly);
            builder.Services.AddMediatR(typeof(RestoController).Assembly);
            //builder.Services.AddMediatR(typeof(RestoDTORequest));
            //builder.Services.AddOptions();

         

           SymmetricSecurityKey llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aBcDeFgHiJkLmNñOpQrStUvWxYz1620.."));
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = llave,
                            ValidateAudience = false,
                            ValidateIssuer = false
                        };
                    });


            //REGISTRA INTERFAZ DE CLASES
            builder.Services.AddScoped<IJWTGen, JWTGen>();
            builder.Services.AddScoped<ISessionUsuario, SessionUsuario>();
            

            //REGISTRA EL CONTEXTO DE LA BASE DE DATOS
            builder.Services.AddDbContext<TenedorYPalillosContext>();


            //REGISTRA IDENTITY USER
            IdentityBuilder identityBuilder = builder.Services.AddIdentityCore<User>();
            IdentityBuilder identity = new IdentityBuilder(identityBuilder.UserType, identityBuilder.Services);
            identity.AddEntityFrameworkStores<TenedorYPalillosContext>();
            identity.AddSignInManager<SignInManager<User>>();
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

                UserManager<User> userManager = serices.GetRequiredService<UserManager<User>>();
                TenedorYPalillosContext context = serices.GetRequiredService<TenedorYPalillosContext>();

                //GENERA EL MODELO DE DATOS A  NIVEL DE DB
                context.Database.Migrate();

                //GENERA E INSERTA USUARIO ROOT AL CONTEXTO DE LA BASE DE DATOS
                ROOT.CreaUsuarioROOT(context, userManager).Wait();

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

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }


    }
}
