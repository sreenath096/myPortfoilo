using AutoMapper;
using MyPortfolio.BAL.Contracts;
using MyPortfolio.Models.Entities;
using MyPortfolio.Models.Models.Users;

namespace MyPortfolio.BAL
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void UpdatePassword(int id, UpdatePasswordRequest model);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Create(CreateRequest model)
        {          
            var user = _mapper.Map<User>(model);
            user.PasswordHash = GeneratePassword(model.Password);
            _userRepository.Create(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(int id, UpdateRequest model)
        {           
            var user = _userRepository.GetById(id);
            _mapper.Map(model, user);
            _userRepository.Update(id, user);
        }

        public void UpdatePassword(int id, UpdatePasswordRequest model)
        {
            var user = _userRepository.GetById(id);

            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = GeneratePassword(model.Password);

            _mapper.Map(model, user);
            _userRepository.Update(id, user);
        }
          
        private string GeneratePassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}