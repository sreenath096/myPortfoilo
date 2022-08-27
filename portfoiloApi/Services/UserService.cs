using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BCrypt.Net;
using portfoiloApi.Entities;
using portfoiloApi.Helpers;
using portfoiloApi.Models.Users;

namespace portfoiloApi.Services
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
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UserService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public void Create(CreateRequest model)
        {
            CheckEmailExists(model.Email);

            var user = _mapper.Map<User>(model);
            user.PasswordHash = GeneratePassword(model.Password);

            _dataContext.Users.Add(user);
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

        public void Update(int id, UpdateRequest model)
        {
            CheckEmailExists(model.Email);

            var user = GetUser(id);

            _mapper.Map(model, user);
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }

        public void UpdatePassword(int id, UpdatePasswordRequest model)
        {
            var user = GetUser(id);

            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = GeneratePassword(model.Password);

            _mapper.Map(model, user);
            _dataContext.Users.Update(user);
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
                throw new AppException($"User with the mail {email} already exists");
        }

        private string GeneratePassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}