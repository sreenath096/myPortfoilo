using MyPortfolio.BAL.Contracts;

namespace MyPortFolio.DAL.Factory
{
    public interface IRepositoryFactory
    {
        IUserRepository UserRepository { get; }
    }
    public class RepositoryFactory : IRepositoryFactory
    {
        public RepositoryFactory()
        {
        }

        public IUserRepository UserRepository => throw new NotImplementedException();
    }
}
