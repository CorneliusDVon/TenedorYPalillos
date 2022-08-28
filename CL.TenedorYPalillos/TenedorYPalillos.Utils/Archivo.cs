using System.Text;
using System.Text.RegularExpressions;


namespace TenedorYPalillos.Utils
{

    public static class Archivo
    {

        private static string _contenidoFile;
        private static string _nombreFile;
        private static string _rutSociedadOrigen;
        private static string _nombreIntegracion;
        private static int _correlativoDocumento;
        private static string _descError;
        private static byte[] _bytesDocumento;


        private static string ContenidoFile { get => _contenidoFile; set => _contenidoFile = value; }
        public static string NombreFile { get => _nombreFile; set => _nombreFile = value; }
        private static string NombreIntegracion { get => _nombreIntegracion; set => _nombreIntegracion = value; }
        private static string RutSociedadOrigen { get => _rutSociedadOrigen; set => _rutSociedadOrigen = value; }
        public static int CorrelativoDocumento { get => _correlativoDocumento; set => _correlativoDocumento = value; }
        public static string DescError { get => _descError; set => _descError = value; }
        public static byte[] BytesDocumento { get => _bytesDocumento; set => _bytesDocumento = value; }



        /// <summary>
        ///     Lee un documento localizado en el servidor y retorna su contenido.
        /// </summary>
        ///
        /// <returns>
        ///    string
        /// </returns>
        ///
        /// <param name="rutSociedad">Rut de la sociedad</param>
        /// <param name="path">path de la localizacion del documento. Ej.:~\[Directorio]\[RutSociedad]\[nombreFile.txt]</param>
        /// <param name="descError">retorna la descripcion de algun error ocurrido en la rutina.</param>
        public static string LeeFile(string rutSociedad, string path, ref string descError)
        {

            string documento = string.Empty;

            try
            {

                string FilePath = Directory.GetCurrentDirectory() + path;


                //ABRE, LEE Y CREA EL File
                using (StreamReader FileLog = File.OpenText(FilePath))
                {
                    documento = FileLog.ReadToEnd();
                }


            }
            catch (Exception ex)
            {
            }
            return documento;
        }



        /// <summary>
        ///     Lee un documento localizado en el servidor y retorna su contenido.
        /// </summary>
        ///
        /// <returns>
        ///    string
        /// </returns>
        ///
        /// <param name="rutSociedad">Rut de la sociedad</param>
        /// <param name="path">path de la localizacion del documento. Ej.:~\[Directorio]\[RutSociedad]\[nombreFile.txt]</param>
        /// <param name="descError">retorna la descripcion de algun error ocurrido en la rutina.</param>
        public static void GeneraFullPath(ref string path, ref string descError)
        {

            string documento = string.Empty;

            try
            {
                string FilePath = Directory.GetCurrentDirectory() + path;
                path = FilePath;
            }
            catch (Exception ex)
            {
            }

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void CreaDocumentoTextoIntegracion(string contenidoFile, string nombreFile, string nombreIntegracion, string rutSociedad)
        {

            ContenidoFile = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreIntegracion = nombreIntegracion;
            NombreFile = nombreFile;

            FuncionFile();

        }


        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void SobreEscribeFileIntegracion(string contenidoFile, string nombreFile, string nombreIntegracion, string rutSociedad)
        {

            ContenidoFile = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreIntegracion = nombreIntegracion;
            NombreFile = nombreFile;

            FuncionReescribeFileIntegracion();

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void SobreEscribeFileTokenDefontana(string contenidoFile, string nombreFile, string nombreIntegracion, string rutSociedad)
        {

            ContenidoFile = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreIntegracion = nombreIntegracion;
            NombreFile = nombreFile;

            FuncionReescribeFileTokenDefontana();

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void CreaDocumentoPDFIntegracion(string contenidoFile, string nombreFile, string nombreIntegracion, ref string pathDocumento, string rutSociedad)
        {

            ContenidoFile = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreIntegracion = nombreIntegracion;
            NombreFile = nombreFile;

            string FilePath = Directory.GetCurrentDirectory() +(@"\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile);
            pathDocumento = NombreFile;

            FuncionFilePDF();

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void CreaDocumentoPDFIntegracionBytes(byte[] contenidoFile, string nombreFile, string nombreIntegracion, string rutSociedad)
        {

            BytesDocumento = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreIntegracion = nombreIntegracion;
            NombreFile = nombreFile;

            FuncionFilePDFBytes();

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void CreaDocumentoPDFDesdeBytesConPath(byte[] contenidoFile, string pathFile, string nombreFile, string rutSociedad, ref string descError)
        {

            BytesDocumento = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreFile = nombreFile;
            NombreIntegracion = pathFile;

            FuncionFilePDFBytesConPath();

            descError = DescError;

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="contenidoFile">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void CreaDocumentoPDFIntegracionAsync(string contenidoFile, string nombreFile, string nombreIntegracion, ref string pathDocumento, string rutSociedad)
        {

            ContenidoFile = contenidoFile;
            RutSociedadOrigen = rutSociedad;
            NombreIntegracion = nombreIntegracion;
            NombreFile = nombreFile;

            string FilePath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
            pathDocumento = FilePath;

            Thread t = new Thread(new ThreadStart(FuncionFilePDF));
            t.Start();

        }



        /// <summary>
        ///     Genera un File dentro del directorio <i>Integracion</i> en conjunto con el directorio que hace referencia al cliente.
        /// </summary>
        ///
        /// <returns>
        ///     void.
        /// </returns>
        ///
        /// <param name="pdf64Documento">String que contiene el mensaje para la linea de log.</param>
        /// <param name="nombreFile">String que contiene el nombre que se le dará al File. Se debe incluir la extencion del File.</param>
        /// <param name="nombreIntegracion">String que contiene el nombre que referencia a la integracion.</param>
        /// <param name="rutSociedad">String que representa el rut del cliente.</param>
        public static void CreaDocumentoPDFIntegracionPathAbsoluto(string pdf64Documento, string pathDirectorio, string nombreFile, string rutSociedad, ref string descError)
        {
            descError = string.Empty;

            ContenidoFile = pdf64Documento;
            RutSociedadOrigen = rutSociedad;
            NombreFile = nombreFile;
            NombreIntegracion = pathDirectorio;

            FuncionFilePDFPathAbsoluto();

            descError = DescError;
        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionFile()
        {

            try
            {

                string nombreFile = NombreFile;
                string cuerpoDocumento = ContenidoFile;
                string FilePath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
                string directorioPath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen;


                if (Directory.Exists(directorioPath))
                {

                    if (!File.Exists(FilePath))
                    {
                        //CREA File LOG
                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(cuerpoDocumento);
                        }
                    }
                    else
                    {

                        string contenidoFile = string.Empty;

                        //ABRE, LEE Y CREA EL File
                        using (StreamReader FileLog = File.OpenText(FilePath))
                        {
                            contenidoFile = FileLog.ReadToEnd();
                        }

                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(contenidoFile + cuerpoDocumento);
                        }
                    }

                }
                else
                {
                    Directory.CreateDirectory(directorioPath);
                    FuncionFile();
                }

            }
            catch (Exception ex)
            {
            }

        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionReescribeFileIntegracion()
        {

            try
            {

                string nombreFile = NombreFile;
                string cuerpoDocumento = ContenidoFile;
                string FilePath = Directory.GetCurrentDirectory()+@"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
                string directorioPath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen;


                if (Directory.Exists(directorioPath))
                {

                    if (!File.Exists(FilePath))
                    {
                        //CREA File LOG
                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(cuerpoDocumento);
                        }
                    }
                    else
                    {
                        File.Delete(FilePath);

                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(cuerpoDocumento);
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(directorioPath);
                    FuncionFile();
                }

            }
            catch (Exception ex)
            {
            }

        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionFilePDF()
        {

            try
            {


                string nombreFile = NombreFile;
                string cuerpoDocumento = ContenidoFile;
                string FilePath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
                string directorioPath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen;


                if (Directory.Exists(directorioPath))
                {

                    if (!File.Exists(FilePath))
                    {

                        byte[] sPDFDecoded = Convert.FromBase64String(cuerpoDocumento);


                        using (FileStream stream = new FileStream(@FilePath, FileMode.CreateNew))
                        {

                            using (BinaryWriter writer = new BinaryWriter(stream))
                            {
                                writer.Write(sPDFDecoded);
                                writer.Close();
                            }

                            stream.Close();
                        }

                    }
                    else
                    {
                        //ABRE, LEE Y CREA EL File
                        File.Delete(FilePath);
                        FuncionFilePDF();
                    }

                }
                else
                {
                    Directory.CreateDirectory(directorioPath);
                    FuncionFilePDF();
                }

            }
            catch (Exception ex)
            {
            }

        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionFilePDFPathAbsoluto()
        {

            try
            {


                //descError = string.Empty;
                //ContenidoFile = pdf64Documento;
                //RutSociedadOrigen = rutSociedad;
                //NombreFile = nombreFile;
                //NombreIntegracion = pathDirectorio;


                string pathAbsoluto = NombreIntegracion + NombreFile;
                DescError = string.Empty;

                if (Directory.Exists(NombreIntegracion))
                {

                    if (!File.Exists(pathAbsoluto))
                    {

                        ASCIIEncoding strFileEnc = new ASCIIEncoding();
                        byte[] cuerpoDocumento = Convert.FromBase64String(ContenidoFile);
                        File.WriteAllBytes(pathAbsoluto, cuerpoDocumento);






                        //byte[] sPDFDecoded = Convert.FromBase64String(ContenidoFile);

                        //using (FileStream stream = new FileStream(pathAbsoluto, FileMode.CreateNew))
                        //{

                        //    using (BinaryWriter writer = new BinaryWriter(stream))
                        //    {
                        //        writer.Write(sPDFDecoded);
                        //        writer.Close();
                        //    }

                        //    stream.Close();
                        //}


                        //Log.Info("[SistemaFiles][CreaDocumentoTextoIntegracion][FuncionFilePDF] Se ha CREADO el File " + nombreFile + " en " + FilePath + ".", RutSociedadOrigen);


                    }
                    else
                    {

                        string contenidoFile = string.Empty;

                        //ELIMINA EL File
                        File.Delete(pathAbsoluto);

                        //Log.Info("[SistemaFiles][CreaDocumentoTextoIntegracion][FuncionFilePDF] Se ha ELIMINADO el File " + nombreFile + " en " + FilePath + ".", RutSociedadOrigen);

                        FuncionFilePDFPathAbsoluto();

                    }

                }
                else
                {

                    Directory.CreateDirectory(pathAbsoluto);

                    //Log.Info("[SistemaFiles][CreaDocumentoTextoIntegracion][FuncionFilePDF] El directorio " + directorioPath + " No existe, intentando crear el directorio " + directorioPath + ".", RutSociedadOrigen);

                    FuncionFilePDFPathAbsoluto();

                }

            }
            catch (Exception ex)
            {
                DescError = ex.Message;
                //Log.Error("[SistemaFiles][CreaDocumentoTextoIntegracion][FuncionFilePDF]Error al intentar crear, leer o modificar el File o directorio [" + ex.Message + "]", RutSociedadOrigen);
            }

        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionFilePDFBytes()
        {

            try
            {

                string nombreFile = NombreFile;
                byte[] cuerpoDocumento = BytesDocumento;
                string FilePath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
                string directorioPath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen;


                if (Directory.Exists(directorioPath))
                {

                    if (!File.Exists(FilePath))
                    {

                        ASCIIEncoding strFileEnc = new ASCIIEncoding();
                        cuerpoDocumento = Convert.FromBase64String(strFileEnc.GetString(cuerpoDocumento));
                        File.WriteAllBytes(FilePath, cuerpoDocumento);



                        //byte[] sPDFDecoded = Convert.FromBase64String(cuerpoDocumento);


                        //using (FileStream stream = new FileStream(@FilePath, FileMode.CreateNew))
                        //{

                        //    using (BinaryWriter writer = new BinaryWriter(stream))
                        //    {
                        //        writer.Write(sPDFDecoded);
                        //        writer.Close();
                        //    }

                        //    stream.Close();
                        //}



                        //ASCIIEncoding strFileEnc = new ASCIIEncoding();
                        //File.WriteAllBytes(nombreFile, cuerpoDocumento);

                    }
                    else
                    {

                        string contenidoFile = string.Empty;

                        //ABRE, LEE Y CREA EL File
                        File.Delete(FilePath);

                        FuncionFilePDFBytes();

                    }

                }
                else
                {

                    Directory.CreateDirectory(directorioPath);

                    FuncionFilePDFBytes();

                }

            }
            catch (Exception ex)
            {
            }

        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionFilePDFBytesConPath()
        {

            try
            {

                byte[] cuerpoDocumento = BytesDocumento;
                string nombreFile = NombreIntegracion + NombreFile;
                string directorioPath = NombreIntegracion;

                DescError = string.Empty;


                ASCIIEncoding strFileEnc = new ASCIIEncoding();
                File.WriteAllBytes(nombreFile, cuerpoDocumento);

            }
            catch (Exception ex)
            {

            }

        }



        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static string ConsultaFilePDFDocumento()
        {

            string pdf64 = string.Empty;

            try
            {

                string nombreFile = NombreFile;
                string cuerpoDocumento = ContenidoFile;
                string FilePath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
                string directorioPath = Directory.GetCurrentDirectory() + @"~\Integracion\" + NombreIntegracion + @"\" + RutSociedadOrigen;


                if (Directory.Exists(directorioPath))
                {

                    if (!File.Exists(FilePath))
                    {

                        //CREA File LOG
                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(cuerpoDocumento);
                        }

                    }
                    else
                    {

                        string contenidoFile = string.Empty;

                        //ABRE, LEE Y CREA EL File
                        using (StreamReader FileLog = File.OpenText(FilePath))
                        {
                            contenidoFile = FileLog.ReadToEnd();
                        }

                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(contenidoFile + cuerpoDocumento);
                        }

                    }

                }
                else
                {

                    Directory.CreateDirectory(directorioPath);
                    FuncionFile();

                }

            }
            catch (Exception ex)
            {
            }


            return pdf64;

        }



        /// <summary>
        ///     Retorna el contenido de un File creado por una integracion con un facturador electronico.
        /// </summary>
        public static string TraePDFDocumentoFisico(string pathFile, string rutSociedad, ref string descError)
        {

            string pdf64 = string.Empty;

            try
            {

                pathFile = Directory.GetCurrentDirectory() + @"~\" + pathFile;

                descError = string.Empty;


                if (File.Exists(pathFile))
                {

                    string contenidoFile = string.Empty;

                    //ABRE Y LEE EL File
                    using (StreamReader FileRespaldoDocumentoFisico = File.OpenText(pathFile))
                    {
                        contenidoFile = FileRespaldoDocumentoFisico.ReadToEnd();
                        FileRespaldoDocumentoFisico.Close();
                    }

                    pdf64 = contenidoFile;
                }
                else
                {
                    descError = "1";
                }

            }
            catch (Exception ex)
            {
                descError = "2";
            }


            return pdf64;

        }


        public static string TraePDF64Documento(string pathAbsolutoFile, string rutSociedad, ref string descError)
        {

            string pdf64 = string.Empty;

            try
            {

                descError = string.Empty;

                if (File.Exists(pathAbsolutoFile))
                {

                    string contenidoFile = string.Empty;

                    ////ABRE Y LEE EL File
                    //using (StreamReader FileRespaldoDocumentoFisico = File.OpenText(pathFile))
                    //{
                    //    contenidoFile = FileRespaldoDocumentoFisico.ReadToEnd();
                    //    FileRespaldoDocumentoFisico.Close();
                    //}

                    Byte[] bytes = File.ReadAllBytes(pathAbsolutoFile);
                    contenidoFile = Convert.ToBase64String(bytes);


                    pdf64 = contenidoFile;

                    descError = "0";

                }
                else
                {
                    descError = "1";
                }

            }
            catch (Exception ex)
            {
                descError = "2";
            }


            return pdf64;

        }


        public static void ReemplazaTextoEnDocumento(string pathFile, string textoBuscar, string reemplazaPor)
        {
            string content = string.Empty;

            using (StreamReader reader = new StreamReader(pathFile))
            {

                content = reader.ReadToEnd();
                reader.Close();

            }

            content = Regex.Replace(content, textoBuscar, reemplazaPor);

            using (StreamWriter writer = new StreamWriter(pathFile))
            {
                writer.Write(content);
                writer.Close();
            }


        }


        /// <summary>
        ///     Funcion de edicion y creacion de documentos de log.
        /// </summary>
        private static void FuncionReescribeFileTokenDefontana()
        {

            try
            {

                string nombreFile = NombreFile;
                string cuerpoDocumento = ContenidoFile;
                string FilePath = Directory.GetCurrentDirectory() + @"~\Configuracion\" + NombreIntegracion + @"\" + RutSociedadOrigen + @"\" + nombreFile;
                string directorioPath = Directory.GetCurrentDirectory() + @"~\Configuracion\" + NombreIntegracion + @"\" + RutSociedadOrigen;


                if (Directory.Exists(directorioPath))
                {
                    if (!File.Exists(FilePath))
                    {
                        //CREA File LOG
                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(cuerpoDocumento);
                        }
                    }
                    else
                    {
                        File.Delete(FilePath);

                        using (StreamWriter FileLog = File.CreateText(FilePath))
                        {
                            FileLog.WriteLine(cuerpoDocumento);
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(directorioPath);
                    FuncionFile();
                }
            }
            catch (Exception ex)
            {
            }

        }


        /// <summary>
        ///     Lee un documento localizado en el servidor y retorna su contenido.
        /// </summary>
        ///
        /// <returns>
        ///    string
        /// </returns>
        ///
        /// <param name="rutSociedad">Rut de la sociedad</param>
        /// <param name="path">path de la localizacion del documento. Ej.:~\[Directorio]\[RutSociedad]\[nombreFile.txt]</param>
        /// <param name="descError">retorna la descripcion de algun error ocurrido en la rutina.</param>
        public static string LeeFileTokenDefontana(string rutSociedad, string path, ref string descError)
        {

            string documento = string.Empty;

            try
            {

                string FilePath = Directory.GetCurrentDirectory() + @"~\Configuracion\Defontana\" + rutSociedad + @"\SessionToken.json";

                //ABRE, LEE Y CREA EL File
                using (StreamReader FileLog = File.OpenText(FilePath))
                {
                    documento = FileLog.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
            }

            return documento;

        }



    }

}
