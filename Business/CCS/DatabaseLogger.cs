using System;

namespace Business.CCS
{
  public class DatabaseLogger : ILogger
  {
    public void Log()
    {
      Console.Write("Veritabanına loglandi.");
    }
  }
}
