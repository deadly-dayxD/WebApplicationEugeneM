using Microsoft.EntityFrameworkCore;
using WebApplicationEugeneM.Models;    // пространство имен класса ApplicationContext

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
