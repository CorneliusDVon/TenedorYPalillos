using System;


namespace TenedorYPalillos.Connection
{
    public static class VariablesConexion
    {
        private const string Instancia = "AORUSX570";
        private const string Usuario = "sa";
        private const string Password = "260786";
        public static readonly string CadenaConexion = "Data Source=" + Instancia + "; Initial Catalog={{BaseDatos}}; User ID=" + Usuario + "; Password=" + Password + ";";
    }
}
