using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationEugeneM.BLL.DTO;

namespace WebApplicationEugeneM.BLL.Interfaces
{
    public interface IService
    {
        void MakeUser(UserDTO userDto);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        void MakeCompany(CompanyDTO companyDto);
        CompanyDTO GetCompany(int? id);
        IEnumerable<CompanyDTO> GetCompanies();
        void Dispose();
    }
}
