using DDDCore.Implement;

namespace Actor.Scripts.Core.Entity
{
    public class Actor : AggregateRoot , IActor
    {
        public Actor(string id) : base(id) { }
    }
}