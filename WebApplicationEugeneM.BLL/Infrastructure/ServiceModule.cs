using Ninject.Modules;
using WebApplicationEugeneM.DAL.Interfaces;
using WebApplicationEugeneM.DAL.Repositories;

namespace WebApplicationEugeneM.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
