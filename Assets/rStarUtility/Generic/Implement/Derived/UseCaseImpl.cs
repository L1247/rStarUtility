#region

using rStarUtility.Util.DDD.UseCase;

#endregion

namespace rStarUtility.Generic.Implement.Derived
{
    public class UseCaseImpl : UseCase<InputImpl , CqrsOutputImpl>
    {
    #region Public Methods

        public CqrsOutputImpl Execute(InputImpl input)
        {
            var cqrsOutput = CqrsOutputImpl.Create();
            return cqrsOutput.Fail().SetMessage("sa1");
        }

    #endregion
    }
}