using Microsoft.AspNetCore.Mvc;
using MyPortfolio.BAL.Factory;

namespace portfoiloApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IServiceFactory _serviceFactory;

        public BaseApiController(IServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("Test")]
        public string Test()
        {
            return $"{ GetType().ToString().Split('.').Last().Replace("Controller", "")} API is live";
        }
    }
}