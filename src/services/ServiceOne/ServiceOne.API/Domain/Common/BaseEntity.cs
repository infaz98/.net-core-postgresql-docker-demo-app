using System.ComponentModel.DataAnnotations;

namespace ServiceOne.API.Domain.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key] public Guid Id { get; }
    }
}