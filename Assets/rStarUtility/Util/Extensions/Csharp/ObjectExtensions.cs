namespace rStarUtility.Util.Extensions.Csharp
{
    public static class ObjectExtensions
    {
    #region Public Methods

        public static bool IsNotNull(this object value)
        {
            return value.IsNull().IsFalse();
        }

        public static bool IsNull(this object value)
        {
            return value == null;
        }

    #endregion
    }
}