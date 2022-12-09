using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RomanNumeralGenerator.Data;

public class RomanNumeralGeneratorDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<LogHistory> History { get; set; }

    public RomanNumeralGeneratorDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("roman-numerals"));
    }
}