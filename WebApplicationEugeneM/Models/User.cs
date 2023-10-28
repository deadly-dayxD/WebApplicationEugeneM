using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplicationEugeneM.Models
{
    public class User
    {
        public int Id { get; set; } // Id пользователя
        public string? Name { get; set; } // имя пользователя
        public int Age { get; set; } // возраст пользователя
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
