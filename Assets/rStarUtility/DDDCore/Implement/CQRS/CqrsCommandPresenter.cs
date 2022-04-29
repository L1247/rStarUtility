#region

using DDDCore.Usecase;
using DDDCore.Usecase.CQRS;

#endregion

namespace ThirtyParty.DDDCore.Implement.CQRS
{
    public class CqrsCommandPresenter : Result , CqrsCommandOutput , Presenter<CqrsCommandViewModel>
    {
    #region Public Variables

        public static CqrsCommandPresenter NewInstance()
        {
            return new CqrsCommandPresenter();
        }

    #endregion

    #region Private Variables

        private readonly CqrsCommandViewModel viewModel;

    #endregion

    #region Constructor

        public CqrsCommandPresenter()
        {
            viewModel = new CqrsCommandViewModel();
        }

    #endregion

    #region Public Methods

        public CqrsCommandViewModel BuildViewModel()
        {
            return viewModel;
        }

        public string GetId()
        {
            return viewModel.GetId();
        }

        public CqrsCommandOutput SetId(string id)
        {
            viewModel.SetId(id);
            return this;
        }

        public override Output SetMessage(string message)
        {
            base.SetMessage(message);
            viewModel.SetMessage(message);
            return this;
        }

    #endregion
    }
}