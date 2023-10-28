using Microsoft.EntityFrameworkCore;
using WebApplicationEugeneM.Models;    // ������������ ���� ������ ApplicationContext

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();
