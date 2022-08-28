using System.Text.RegularExpressions;
using TenedorYPalillos.Model.DTO.Log;


namespace TenedorYPalillos.Utils
{

    public static class Valida
    {

        public static string LimpiaTextoER(string texto)
        {

            string nuevoTexto = string.Empty;
            const string expresionesIrregulares = @"[^\w ]";

            try
            {
                Regex regex = new Regex(expresionesIrregulares);
                nuevoTexto = regex.Replace(texto, "");
            }
            catch (Exception)
            {
            }

            return nuevoTexto;

        }

        public static bool Email(string email)
        {

            const string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool isOK = false;


            try
            {
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                    {
                        isOK = true;
                    }
                    else
                    {
                        isOK = false;
                    }
                }
                else
                {
                    isOK = false;
                }
            }
            catch (Exception ex)
            {
                isOK = false;

                Log.Error(new LogResquestDTO
                {
                    Society = "ROOT",
                    Date = DateTime.Now,
                    LibraryClass = "Valida",
                    Method = "Email",
                    Message = "No se ha podido validar el email [" + email + "]",
                    Detail = ex.Message
                });
            }

            return isOK;

        }

        public static bool RutCL(string rut)
        {

            bool isOK = false;

            int m = 0;
            int s = 1;

            try
            {

                rut = rut.ToUpper();
                rut = rut.Replace(".", string.Empty);
                rut = rut.Replace("-", string.Empty);


                int rutAuxiliar = int.Parse(rut.Substring(0, rut.Length - 1));
                char digitoVerificador = char.Parse(rut.Substring(rut.Length - 1, 1));


                for (; rutAuxiliar != 0; rutAuxiliar /= 10)
                {
                    s = (s + rutAuxiliar % 10 * (9 - m++ % 6)) % 11;
                }

                if (digitoVerificador == (char)(s != 0 ? s + 47 : 75))
                {
                    isOK = true;
                }

            }
            catch (Exception ex)
            {
                isOK = false;

                Log.Error(new LogResquestDTO
                {
                    Society = "ROOT",
                    Date = DateTime.Now,
                    LibraryClass = "Valida",
                    Method = "RutCL",
                    Message = "No se ha podido validar el rut [" + rut + "]",
                    Detail = ex.Message
                });
            }

            return isOK;

        }

    }

}
