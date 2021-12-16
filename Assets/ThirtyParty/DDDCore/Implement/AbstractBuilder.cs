namespace DDDCore.Implement
{
    /// <summary>
    /// </summary>
    /// <typeparam name="B">Builder self</typeparam>
    /// <typeparam name="E">Entity of aggregate root</typeparam>
    public abstract class AbstractBuilder<B , E> where B : new() where E : AggregateRoot
    {
    #region Public Variables

        public static B NewInstance()
        {
            return new B();
        }

    #endregion

    #region Public Methods

        public abstract E Build();

    #endregion
    }
}