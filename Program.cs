using Microsoft.EntityFrameworkCore;
using wt_lab8_8razor_postgresql_pravotorova.Data;

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения (локально и на Render)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

if (!string.IsNullOrWhiteSpace(databaseUrl))
{
    var uri = new Uri(databaseUrl);
    var userInfo = uri.UserInfo.Split(':', 2);
    int dbPort = uri.Port > 0 ? uri.Port : 5432;

    connectionString = $"Host={uri.Host};Port={dbPort};Database={uri.AbsolutePath.TrimStart('/')};" +
                       $"Username={Uri.UnescapeDataString(userInfo[0])};Password={Uri.UnescapeDataString(userInfo[1])};" +
                       $"SSL Mode=Require;Trust Server Certificate=true";
}

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddRazorPages();

var app = builder.Build();

// Автоматическое применение миграций при запуске
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");