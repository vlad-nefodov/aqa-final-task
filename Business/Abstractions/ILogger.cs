namespace Business.Abstractions;

public interface ILogger
{
    void Debug(string message);

    void Trace(string message);

    void Warn(string message);

    void Error(string message);
}