namespace ThirtyParty.DDDCore.Implement.CQRS
{
    public class CqrsCommandViewModel : ViewModel
    {
    #region Private Variables

        private string id;
        private string message;

    #endregion

    #region Public Methods

        public string GetId()
        {
            return id;
        }

        public string GetMessage()
        {
            return message;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public void SetMessage(string message)
        {
            this.message = message;
        }

    #endregion
    }
}