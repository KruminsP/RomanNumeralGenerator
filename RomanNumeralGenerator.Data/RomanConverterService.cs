using Microsoft.Extensions.Configuration;

namespace RomanNumeralGenerator.Data;

public class RomanConverterService : RomanNumeralGeneratorDbContext
{
    private readonly RomanNumeralGeneratorDbContext _context;
    private readonly Generator _generator;
    public RomanConverterService(IConfiguration configuration, RomanNumeralGeneratorDbContext context, Generator generator) : base(configuration)
    {
        _context = context;
        _generator = generator;
    }

    public LogHistory AddLog(LogHistory log)
    {
        log.Time = DateTime.Now.ToString();
        log.Output = _generator.Generate(log.Input);
        _context.History.Add(log);
        _context.SaveChanges();

        return log;
    }
}