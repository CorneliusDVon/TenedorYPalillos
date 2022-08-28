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

            string path = string.Empty;

            try
            {

                Logger = LogManager.GetCurrentClassLogger();
                LoggingConfiguration config = new();


                //D:\DESARROLLO\.NET CORE\LLEGOCARTA\DEV_UNIT_TEST
                //string webRootPath = IWebHostEnvironment.WebRootPath;
                //string contentRootPath = IWebHostEnvironment.ContentRootPath;
                path = Path.Combine(Directory.GetCurrentDirectory(), "");


                FileTarget fileTarget = new()
                {
                    Name = "Log",
                    Encoding = Encoding.UTF8,
                    Layout = "[${longdate}] ${message:withexception=true}",//"${logger} ${longdate} ${level:uppercase=true} ${message:withexception=true}",
                    LineEnding = LineEndingMode.CR,
                    FileName = path + @"\log\" + LogInfo.Society + @"\${level:uppercase=true}_" + DateTime.Now.ToShortDateString().Replace("-", "_") + ".log",
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

                //MailTarget mailTarget = new()
                //{
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
                //};

                //BufferingTargetWrapper buffer = new(mailTarget, 5);
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
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, fileTarget));
                        //SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Info);
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, consoleTarget));
                        break;

                    case 2:
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, fileTarget));
                        //SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Error);
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Error, consoleTarget));
                        break;

                    case 3:
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));
                        //SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Debug);
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
                        break;

                    case 4:
                        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, fileTarget));
                        //SimpleConfigurator.ConfigureForTargetLogging(buffer, LogLevel.Trace);
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, mailTarget));
                        //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, consoleTarget));
                        break;

                    default:
                        break;
                }

                Logger.Factory.Configuration = config;

            }
            catch (Exception ex)
            {
                var stop = 0;
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
            catch (Exception ex)
            {
                var stop = 0;
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
