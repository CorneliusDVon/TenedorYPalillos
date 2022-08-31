using Microsoft.EntityFrameworkCore;
using TenedorYPalillos.Model.DAO.RestoEntity;


namespace TenedorYPalillos.Connection.Context
{

    public class RestoContext : DbContext
    {

        private string _rutSociedad;
        private DbSet<Resto> _resto;
        private DbSet<Resto_Tipo_Resto> _restoTipoResto;
        private DbSet<Tipo_Resto> _tipoResto;


        public RestoContext()
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

                cadenaConexion = VariablesConexion.CadenaConexion.Trim().Replace("{{BaseDatos}}", baseDatosSociedad.Trim());

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
