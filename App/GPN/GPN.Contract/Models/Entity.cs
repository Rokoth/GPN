using GPN.Contract.Abstractions;

namespace GPN.Contract.Models
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
    }
}
