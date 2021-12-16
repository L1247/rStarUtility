#region

using DDDCore.Implement;

#endregion

namespace Actor.Scripts.Core.Entity
{
    public class ActorBuilder : AbstractBuilder<ActorBuilder , Actor>
    {
    #region Private Variables

        private string id;

    #endregion

    #region Public Methods

        public override Actor Build()
        {
            return new Actor(id);
        }

        public ActorBuilder SetId(string id)
        {
            this.id = id;
            return this;
        }

    #endregion
    }
}