#region

using Zenject;

#endregion

namespace Sample
{
    public class TestMonoInstaller : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            TestSoInstaller.InstallThis(Container);
        }

    #endregion
    }
}