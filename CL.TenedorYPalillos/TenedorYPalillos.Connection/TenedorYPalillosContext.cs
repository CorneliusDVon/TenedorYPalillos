using LLegoCarta.DBConnection;
using TenedorYPalillos.Model.DAO.Resto;
using TenedorYPalillos.Utils;
using Microsoft.EntityFrameworkCore;


namespace TenedorYPalillosDBContext
{

    public class TenedorYPalillosContext : DbContext
    {

        //private const string _cadenaConexion = "Data Source=AORUSX570; Initial Catalog=LLEGOCARTA; User ID=sa; Password=260786;";
        private DbSet<Resto> _resto;
        private DbSet<Resto_Tipo_Resto> _restoTipoResto;
        private DbSet<Tipo_Resto> _tipoResto;
        private string _rutSociedad;


        public TenedorYPalillosContext()
        {

        }


        //private static string CadenaConexion => _cadenaConexion;
        public string RutSociedad { get => _rutSociedad; set => _rutSociedad = value; }
        public DbSet<Resto> Resto { get => _resto; set => _resto = value; }
        public DbSet<Resto_Tipo_Resto> Resto_Tipo_Resto { get => _restoTipoResto; set => _restoTipoResto = value; }
        public DbSet<Tipo_Resto> Tipo_Resto { get => _tipoResto; set => _tipoResto = value; }



        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {

            string cadenaConexion = string.Empty;
            string baseDatosSociedad = string.Empty;

            try
            {

                //IMPLEMENTAR BUSQUEDA DE BASE DE DATOS POR USUARIO SI LO AMERITA
                baseDatosSociedad = "TENEDORYPALILLOS";

                cadenaConexion = "Data Source=" + VariablesConexion.Instancia + "; Initial Catalog=" + baseDatosSociedad + "; User ID=" + VariablesConexion.Usuario + "; Password=" + VariablesConexion.Password + ";";


                //Log.Debug("Msg:[Se ha cargado la informacion para la conexion a la base de datos] Det:[" + RutSociedad + "]", RutSociedad);


                dbContextOptionsBuilder.UseSqlServer(cadenaConexion);

            }
            catch (Exception ex)
            {
                //Log.Error("Msg:[Se ha generado un error al intentar generar el contexto] Det:[" + ex.Message + "]", RutSociedad);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SE DENOTA QUE LA TABLA Resto_Tipo_Resto POSEE UNA CLAVE PRIMARIA COMPUESTA
            modelBuilder.Entity<Resto_Tipo_Resto>().HasKey(rtr => new { rtr.ID_Resto, rtr.ID_Tipo_Resto });
        }


    }


}
