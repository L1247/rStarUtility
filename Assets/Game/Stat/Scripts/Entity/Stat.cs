#region

using DDDCore.Implement;

#endregion

namespace Stat.Entity
{
    public class Stat : AggregateRoot , IStat
    {
    #region Constructor

        public Stat(string id) : base(id) { }

    #endregion
    }
}