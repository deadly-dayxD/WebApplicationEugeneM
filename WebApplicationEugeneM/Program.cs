using Microsoft.EntityFrameworkCore;
using WebApplicationEugeneM.Models;    // пространство имен класса ApplicationContext
using WebAppBackgroundService;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));
builder.Services.AddBackgroundServices();
builder.Services.AddControllersWithViews();
builder.Services.AddHostedService<MyHostedService>();

var app = builder.Build();
app.MapDefaultControllerRoute();
app.Run();
