namespace COOLLenguage.Utils
{
    public interface IErrorLogger
    {
        int CountErrors { get; }
        void LogError(string ErrorMessage);
    }
}
