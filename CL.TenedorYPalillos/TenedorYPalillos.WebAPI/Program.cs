using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Connection.Context;
using TenedorYPalillos.Model.DTO.Resto;

namespace TenedorYPalillos.WebAPI
{

    public class Program
    {

        public static void Main(string[] args)
        {


            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            //Add services to the container.
            builder.Services.AddControllers();

            //REGISTRO DE MEDIATR
            builder.Services.AddMediatR(typeof(RestoController).GetTypeInfo().Assembly);
            builder.Services.AddMediatR(typeof(RestoDTORequest));
            builder.Services.AddOptions();

            //Agregar el Context si se va a utilizr un Handler
            builder.Services.AddDbContext<RestoContext>();




            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {                
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }


    }
}
