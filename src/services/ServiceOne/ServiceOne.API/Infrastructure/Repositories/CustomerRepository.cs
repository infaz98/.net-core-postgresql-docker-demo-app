using Microsoft.EntityFrameworkCore;
using ProjectManagement.Infrastructure;
using ServiceOne.API.Domain;
using ServiceOne.API.Infrastructure.Interfaces;

namespace ServiceOne.API.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
        {
            _applicationDataContext = applicationDataContext;
            _customers = _applicationDataContext.Set<Customer>();
        }
    }
}
