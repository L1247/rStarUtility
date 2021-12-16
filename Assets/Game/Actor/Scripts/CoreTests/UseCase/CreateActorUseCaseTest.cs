using Actor.Scripts.Core.UseCase;
using DDDCore.Event;
using DDDTestFrameWork;
using NUnit.Framework;
using Zenject;

namespace Tests
{
    public class CreateActorUseCaseTest : ExntenjectUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void SuccessCase()
        {
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<IDomainEventBus>().FromSubstitute();
            Container.Bind<IActorRepository>().FromSubstitute();
            var createActorInput   = new CreateActorInput();
            var createActorUseCase = Container.Resolve<CreateActorUseCase>();
            createActorUseCase.Execute(createActorInput);
        }

    #endregion
    }
}