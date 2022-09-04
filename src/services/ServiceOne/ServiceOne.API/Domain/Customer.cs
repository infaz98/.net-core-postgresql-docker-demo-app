using ServiceOne.API.Domain.Common;

namespace ServiceOne.API.Domain
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
