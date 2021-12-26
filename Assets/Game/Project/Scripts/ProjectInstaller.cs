using DDDCore.Implement;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
#region Overrides of MonoInstallerBase

    public override void InstallBindings()
    {
        DDDInstaller.Install(Container);
    }

#endregion
}