using RomanNumeralGenerator;
using RomanNumeralGenerator.Data;
using RomanNumeralGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IRomanNumeralGeneratorDbContext, RomanNumeralGeneratorDbContext>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IEntityService<LogHistory>, EntityService<LogHistory>>();
builder.Services.AddScoped<ILogHistoryService, LogHistoryService>();
//builder.Services.AddScoped<RomanConverterService>();
builder.Services.AddScoped<Generator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
