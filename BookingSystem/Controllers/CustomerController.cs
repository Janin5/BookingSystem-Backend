using BookingSystem.InterfacesRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    { 
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [Authorize]
        [HttpPost("ProvisionCustomer")]
        public async Task<IActionResult> ProvisionCustomer()
        {

            var auth0Id = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;

            if (auth0Id is null)
            {
                return Unauthorized();
            }
            
                var customer = await _customerRepository.GetByAuth0Id(auth0Id);
                if (customer == null)
                {
                    _customerRepository.Create(new Models.Customer()
                    {
                        Email = User.FindFirst("email")?.Value,
                        Auth0Id = auth0Id
                    });

               await _customerRepository.SaveChangesAsync();
                }

            return Ok();
            
        }


    }

}
