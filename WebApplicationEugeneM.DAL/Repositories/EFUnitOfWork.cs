using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WebApplicationEugeneM.DAL.Interfaces;
using WebApplicationEugeneM.DAL.Entities;
using WebApplicationEugeneM.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationEugeneM.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private UsersContext db;
        private UserRepository userRepository;
        private CompanyRepository companyRepository;

        public EFUnitOfWork(DbContextOptions<UsersContext> options)
        {
            db = new UsersContext(options);
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<Company> Companies
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(db);
                return companyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
