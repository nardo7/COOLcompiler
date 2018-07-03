using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COOLLenguage.Utils
{
    public interface IErrorLogger
    {
        int CountErrors { get; }
        void LogError(string ErrorMessage);
    }
}
