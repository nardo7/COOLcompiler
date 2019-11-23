using System.IO;

namespace COOLLenguage.Utils
{

    public class ErrorLogger:IErrorLogger
    {
        TextWriter Logger;
        int countErrors;
        public ErrorLogger(TextWriter logger)
        {
            Logger = logger;
            countErrors = 0;
        }

        public int CountErrors
        {
            get
            {
                return countErrors;
            }
        }

        public void LogError(string ErrorMessage)
        {
            countErrors++;
            Logger.WriteLine(ErrorMessage);
        }
    }
}
