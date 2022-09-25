using AutoMapper;
using MyPortfolio.BAL.Contracts;

namespace MyPortfolio.BAL.Factory
{
    public interface IServiceFactory
    {
        IUserService UserService { get; }
        ILoginService LoginService { get; }
    }

    public class ServiceFactory : IServiceFactory
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ServiceFactory(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IUserService UserService =>  new UserService(_userRepository, _mapper);
        public ILoginService LoginService => new LoginService(_mapper);
    }
}
