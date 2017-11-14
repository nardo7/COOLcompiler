using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace COOLLenguage.Utils
{
    
    public class ErrorLogger:IErrorLogger
    {
        TextWriter Logger;

        public ErrorLogger(TextWriter logger)
        {
            Logger = logger;
        }

        public void LogError(string ErrorMessage)
        {
            Logger.Write(ErrorMessage);
        }
    }
}
