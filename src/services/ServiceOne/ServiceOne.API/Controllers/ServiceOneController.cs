using Microsoft.AspNetCore.Mvc;
using ServiceOne.API.Domain;
using ServiceOne.API.Infrastructure.Interfaces;
using ServiceOne.API.Models;

namespace ServiceOne.API.Controllers
{
    [ApiController]
    [Route("customer")]
    public class ServiceOneController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public ServiceOneController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Customer?>> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            var customer = new Customer();

            customer.Name = addCustomerRequest.Name;
            customer.Address = addCustomerRequest.Address;

            var response = await _customerRepository.AddAsync(customer);

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return Ok(await _customerRepository.ListAllAsync());
        }


    }
}