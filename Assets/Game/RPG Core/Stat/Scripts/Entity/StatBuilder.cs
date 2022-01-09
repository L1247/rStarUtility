#region

using DDDCore.Implement;
using ThirtyParty.Utilities;

#endregion

namespace Stat.Entity
{
    public class StatBuilder : AbstractBuilder<StatBuilder , Stat>
    {
    #region Private Variables

        private string id;
        private string actorId;

    #endregion

    #region Public Methods

        public override Stat Build()
        {
            if (string.IsNullOrEmpty(id)) id = GUID.NewGUID();
            var stat                         = new Stat(id , actorId);
            return stat;
        }

        public StatBuilder SetActorId(string id)
        {
            actorId = id;
            return this;
        }

    #endregion
    }
}