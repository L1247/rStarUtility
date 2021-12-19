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

    #endregion

    #region Public Methods

        public override Stat Build()
        {
            if (string.IsNullOrEmpty(id)) id = GUID.NewGUID();
            var stat                         = new Stat(id);
            return stat;
        }

    #endregion
    }
}