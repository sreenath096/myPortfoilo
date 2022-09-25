using AutoMapper;

namespace MyPortfolio.BAL
{
    public interface ILoginService
    {
        bool ValidatePassword(string passwordHash, string? password);
    }
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        public LoginService(IMapper mapper)
        {            
            _mapper = mapper;
        }
       
        public bool ValidatePassword(string passwordHash, string? password)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(password))            
                result = BCrypt.Net.BCrypt.Verify(password, passwordHash);            
                            
            return result;
        }       
    }
}