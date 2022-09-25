using MyPortfolio.Models.Entities;

namespace MyPortfolio.BAL.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(User model);
        void Update(int id, User model);
        void UpdatePassword(int id, User model);
        void Delete(int id);
    }
}
