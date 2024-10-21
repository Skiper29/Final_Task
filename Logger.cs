using log4net;
using log4net.Config;

namespace OnlineStore;

public class Logger
{
    private static readonly ILog Log = LogManager.GetLogger(typeof(Logger));
    
    static Logger()
    {
        try
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error configuring log4net: " + ex.Message);
        }
    }
    
    public static void LogError(string message, Exception ex)
    {
        Log.Error(message, ex);
    }
    
    public static void LogInfo(string message)
    {
        Log.Info(message);
    }

    public static void LogWarning(string message)
    {
        Log.Warn(message);
    }
}