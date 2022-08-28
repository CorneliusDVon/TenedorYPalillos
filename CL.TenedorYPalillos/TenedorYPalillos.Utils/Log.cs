using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using System.Text;
using TenedorYPalillos.Model.DTO.Log;


namespace TenedorYPalillos.Utils
{

    public static class Log
    {

        private static Logger _logger;
        private static LogResquestDTO _logInfo;


        private static Logger Logger { get => _logger; set => _logger = value; }
        private static LogResquestDTO LogInfo { get => _logInfo; set => _logInfo = value; }



        private static void CargaConfiguracion(int level)
        {

            //ICollection<string> collection = new List<string>();

            string path = string.Empty;

            try
            {

                Logger = LogManager.GetCurrentClassLogger();
                LoggingConfiguration config = new LoggingConfiguration();


                //D:\DESARROLLO\.NET CORE\LLEGOCARTA\DEV_UNIT_TEST
                //string webRootPath = IWebHostEnvironment.WebRootPath;
                //string contentRootPath = IWebHostEnvironment.ContentRootPath;
                path = Path.Combine(Directory.GetCurrentDirectory(), "");


                var stop = 0;

                FileTarget ft = new FileTarget()
                {
                    Name = "Log",
                    Encoding = Encoding.UTF8,
                    Layout = "[${longdate}] [${logger}] ${message:withexception=true}",//"${logger} ${longdate} ${level:uppercase=true} ${message:withexception=true}",
                    LineEnding = LineEndingMode.CR,
                    FileName = path + @"\log\" + LogInfo.Society + @"_${level:uppercase=true}_" + DateTime.Now.ToShortDateString().Replace("-", "_") + ".log",
                    FileAttributes = Win32FileAttributes.Normal,
                    CreateDirs = true,
                    ConcurrentWrites = true,
                    //ReplaceFileContentsOnEachWrite = false,
                    //DeleteOldFileOnStartup = false,
                    //EnableFileDelete = true,
                    //Header = "Layout",
                    //Footer = "Layout",
                    //ArchiveAboveSize = "Long",
                    //MaxArchiveFiles = "Integer",
                    //MaxArchiveDays = 0,
                    //ArchiveFileName = "Layout",
                    //ArchiveNumbering = ArchiveNumberingMode.Date,
                    //ArchiveDateFormat = "String",
                    //ArchiveEvery = FileArchivePeriod.Day,
                    //ArchiveOldFileOnStartup = "Boolean",
                    //ArchiveOldFileOnStartupAboveSize = "Long",
                    //OpenFileFlushTimeout = "Integer",
                    //OpenFileCacheTimeout = "Integer",
                    //OpenFileCacheSize = "Integer",
                    //NetworkWrites = "Boolean",
                    //ConcurrentWriteAttemptDelay = 1,
                    //ConcurrentWriteAttempts = 1,
                    //BufferSize = "Integer",
                    //AutoFlush = "Boolean",
                    //KeepFileOpen = "Boolean",
                    //ForceManaged = "Boolean",
                    //EnableArchiveFileCompression = "Boolean",
                    //CleanupFileName = "Boolean",
                    //WriteFooterOnArchivingOnly = "Boolean",
                    //WriteBom = "Boolean",
                };

                /*
                "ListaDistribucion": [
                  {
                    //NOTIFICACION CIERRE DE CAJA
                    "Tipo": 1,
                    "plantilla": "NotificacionCierreCaja.html",
                    "Remitente": 
                    [
                      "noreply_ecloud@dominio.cl"
                    ],
                    "Receptor": [
                      {
                        "NombreReceptor": "",
                        "EmailReceptor": ""
                      },
                      {
                        "NombreReceptor": "",
                        "EmailReceptor": ""
                      }
                    ]
                  }
                ]
                */

                MailTarget mailTarget = new MailTarget()
                {
                    //SmtpServer = "mail.cardinale.cl",
                    //SmtpPort=25,
                    //SmtpUserName= "calzado@cardinale.cl",
                    //SmtpPassword= "calzado1831",
                    //SmtpAuthentication = SmtpAuthenticationMode.Basic,
                    //EnableSsl = false,
                    //Html = true,
                    //Encoding = Encoding.UTF8,
                    //Layout = "${message}",
                    //Priority = "High", 
                    //From = "Integracion@e-cloud.cl",
                    //To = "jose.toro.salas@gmail.com",
                    //Subject = "MENSAJE DE NOTIFICACION DE ERROR",
                    //Body = "${message}${newline}"
                };


                BufferingTargetWrapper buffer = new BufferingTargetWrapper(mailTarget, 5);
                //SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Error);


                //ConsoleTarget consoleTarget = new ConsoleTarget()
                //{
                //    Name = "LogConsole",
                //};


                //config.AddTarget(ft);
                //config.AddTarget(mt);


                switch (level)
                {
                    case 1:
                        SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Info);
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, ft));
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, ct));
                        break;

                    case 2:
                        SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Error);
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, ft));
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, ct));
                        break;

                    case 3:
                        SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Debug);
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, ft));
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, ct));
                        break;

                    case 4:
                        SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Trace);
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, ft));
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, ct));
                        break;

                    default:
                        break;
                }

                Logger.Factory.Configuration = config;

            }
            catch (Exception)
            {
            }

        }


        public static void Info(LogResquestDTO request)
        {
            try
            {
                LogInfo = request;
                CargaConfiguracion(1);
                Logger.Info(request.ToString());
            }
            catch (Exception)
            {
            }
        }


        public static void Error(LogResquestDTO request)
        {
            try
            {
                LogInfo = request;
                CargaConfiguracion(2);
                Logger.Error(request.ToString());
            }
            catch (Exception)
            {
            }
        }


        public static void Debug(LogResquestDTO request)
        {
            try
            {
                LogInfo = request;
                CargaConfiguracion(3);
                Logger.Debug(request.ToString());
            }
            catch (Exception)
            {
            }
        }


        public static void Trace(LogResquestDTO request)
        {
            try
            {
                LogInfo = request;
                CargaConfiguracion(4);
                Logger.Trace(request.ToString());
            }
            catch (Exception)
            {
            }
        }


    }

}
