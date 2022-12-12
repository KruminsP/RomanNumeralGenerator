using RomanNumeralGenerator.Data;

namespace RomanNumeralGenerator.Services;

public class LogHistoryService : EntityService<LogHistory>, ILogHistoryService
{
    private readonly IRomanNumeralGenerator _generator;

    public LogHistoryService(IRomanNumeralGeneratorDbContext context, IRomanNumeralGenerator generator) : base(context)
    {
        _generator = generator;
    }

    public LogHistory AddLog(LogHistory log)
    {
        log.Time = DateTime.Now.ToString();
        log.Output = _generator.Generate(log.Input);
        Create(log);

        return log;
    }
}