#region

using System;
using System.Collections.Generic;

#endregion

namespace rStarUtility.Generic.TestFrameWork
{
    public class Scenario
    {
    #region Private Variables

        private List<Action> actions;

    #endregion

    #region Constructor

        public Scenario()
        {
            actions = new List<Action>();
        }

    #endregion

    #region Public Methods

        public Scenario And(string description , Action action)
        {
            actions.Add(action);
            return this;
        }

        public void Execute()
        {
            actions.ForEach(action => action.Invoke());
        }

        public Scenario Given(string description , Action action)
        {
            actions.Add(action);
            return this;
        }

        public Scenario Then(string description , Action action)
        {
            actions.Add(action);
            return this;
        }

        public Scenario When(string description , Action action)
        {
            actions.Add(action);
            return this;
        }

    #endregion
    }
}