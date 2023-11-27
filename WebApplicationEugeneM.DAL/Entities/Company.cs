
namespace WebApplicationEugeneM.DAL.Entities
{
    public class Company
    {
        public int Id { get; set; } // Id компании
        public string? Name { get; set; } // название компании
        public List<User> Users { get; set; } = new();
    }
}