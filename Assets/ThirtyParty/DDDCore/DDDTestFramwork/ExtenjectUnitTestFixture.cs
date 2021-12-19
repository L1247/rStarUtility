#region

using System;
using NUnit.Framework;
using Zenject;

#endregion

namespace DDDTestFrameWork
{
    public abstract class ExtenjectUnitTestFixture
    {
    #region Protected Variables

        protected DiContainer Container { get; private set; }

    #endregion

    #region Setup/Teardown Methods

        [SetUp]
        public virtual void Setup()
        {
            Container = new DiContainer(StaticContext.Container);
        }

        [TearDown]
        public virtual void Teardown()
        {
            StaticContext.Clear();
        }

    #endregion

    #region Protected Methods

        protected string NewGuid()
        {
            return Guid.NewGuid().ToString();
        }

        protected Scenario Scenario(string annotation)
        {
            return new Scenario();
        }

    #endregion
    }
}