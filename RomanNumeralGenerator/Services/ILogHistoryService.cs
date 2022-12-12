namespace RomanNumeralGenerator.Services;

public interface ILogHistoryService : IEntityService<LogHistory>
{
    LogHistory AddLog(LogHistory log);
}