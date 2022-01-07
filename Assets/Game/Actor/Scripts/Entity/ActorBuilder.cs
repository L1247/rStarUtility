#region

using DDDCore.Implement;
using ThirtyParty.Utilities;

#endregion

namespace Actor.Entity
{
    public class ActorBuilder : AbstractBuilder<ActorBuilder , Actor>
    {
    #region Private Variables

        private string id;
        private string dataId;

    #endregion

    #region Public Methods

        public override Actor Build()
        {
            if (string.IsNullOrEmpty(id)) id = GUID.NewGUID();
            var actor                        = new Actor(id , dataId);
            return actor;
        }

        public ActorBuilder SetDataId(string dataId)
        {
            this.dataId = dataId;
            return this;
        }

        public ActorBuilder SetId(string id)
        {
            this.id = id;
            return this;
        }

    #endregion
    }
}