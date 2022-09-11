using MyPortfolio.BAL.Contracts;
using MyPortfolio.Common.Exception;
using MyPortfolio.Models.Entities;

namespace MyPortFolio.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerDataContext _dataContext;        
        public UserRepository(SqlServerDataContext dataContext)
        {
            _dataContext = dataContext;            
        }

        public void Create(User model)
        {
            CheckEmailExists(model.Email);          

            _dataContext.Users.Add(model);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetUser(id);
            _dataContext.Users.Remove(user);
            _dataContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dataContext.Users;
        }

        public User GetById(int id)
        {
            return GetUser(id);
        }

        public void Update(int id, User model)
        {
            CheckEmailExists(model.Email);            
            _dataContext.Users.Update(model);
            _dataContext.SaveChanges();
        }

        public void UpdatePassword(int id, User model)
        {          
            _dataContext.Users.Update(model);
            _dataContext.SaveChanges();
        }

        private User GetUser(int id)
        {
            var user = _dataContext.Users.Find(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");
            return user;
        }

        private void CheckEmailExists(string? email)
        {
            if (!string.IsNullOrEmpty(email) && _dataContext.Users.Any(x => x.Email == email))
                throw new PortfolioApiException($"User with the mail {email} already exists");
        }      
    }
}
