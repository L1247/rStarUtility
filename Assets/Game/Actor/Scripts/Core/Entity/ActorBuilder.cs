using DDDCore.Implement;
using ThirtyParty.Utilities;

namespace Actor.Scripts.Core.Entity
{
    public class ActorBuilder : AbstractBuilder<ActorBuilder , Actor>
    {
    #region Overrides of AbstractBuilder<ActorBuilder,Actor>

        public override Actor Build()
        {
            return new Actor(GUID.NewGUID());
        }

    #endregion
    }
}