using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;

namespace RomanNumeralGenerator.Data;

public interface IRomanNumeralGeneratorDbContext
{
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    DbSet<LogHistory> History { get; set; }
    int SaveChanges();
}