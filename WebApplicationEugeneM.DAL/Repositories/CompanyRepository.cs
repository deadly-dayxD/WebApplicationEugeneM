using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationEugeneM.DAL.EF;
using WebApplicationEugeneM.DAL.Entities;
using WebApplicationEugeneM.DAL.Interfaces;

namespace WebApplicationEugeneM.DAL.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private UsersContext db;

        public CompanyRepository(UsersContext context)
        {
            this.db = context;
        }

        public IEnumerable<Company> GetAll()
        {
            return db.Companies;
        }

        public Company Get(int id)
        {
            return db.Companies.Find(id);
        }

        public void Create(Company company)
        {
            db.Companies.Add(company);
        }

        public void Update(Company company)
        {
            db.Entry(company).State = EntityState.Modified;
        }

        public IEnumerable<Company> Find(Func<Company, Boolean> predicate)
        {
            return db.Companies.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Company company = db.Companies.Find(id);
            if (company != null)
                db.Companies.Remove(company);
        }
    }
}
