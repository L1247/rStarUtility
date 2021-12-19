#region

using System;
using DDDTestFrameWork;

#endregion

namespace ThirtyParty.DDDCore.DDDTestFramwork
{
    public static class ScenarioExtension
    {
    #region Public Variables

        public static Scenario And(this Scenario scenario , string annotation , Action action)
        {
            action.Invoke();
            return scenario;
        }

        public static Scenario Given(this Scenario scenario , string annotation , Action action)
        {
            action.Invoke();
            return scenario;
        }

        public static Scenario Then(this Scenario scenario , string annotation , Action action)
        {
            action.Invoke();
            return scenario;
        }

        public static Scenario When(this Scenario scenario , string annotation , Action action)
        {
            action.Invoke();
            return scenario;
        }

    #endregion
    }
}