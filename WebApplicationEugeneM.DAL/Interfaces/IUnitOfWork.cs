using System;
using WebApplicationEugeneM.DAL.Entities;

namespace WebApplicationEugeneM.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Company> Companies { get; }
        void Save();
    }
}
