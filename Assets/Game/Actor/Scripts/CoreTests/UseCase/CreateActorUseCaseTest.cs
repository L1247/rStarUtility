#region

using Actor.Scripts.Core.UseCase;
using DDDCore.Event;
using DDDTestFrameWork;
using NSubstitute;
using NUnit.Framework;
using Zenject;

#endregion

namespace Actor.Scripts.CoreTests.UseCase
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
            var createActorUseCase = Container.Resolve<CreateActorUseCase>();
            var repository         = Container.Resolve<IActorRepository>();

            Core.Entity.Actor actor = null;
            repository.Save(Arg.Do<Core.Entity.Actor>(_ => actor = _));

            var createActorInput = new CreateActorInput();
            var actorId          = NewGuid();
            createActorInput.Id = actorId;
            createActorUseCase.Execute(createActorInput);

            repository.ReceivedWithAnyArgs(1).Save(null);
            Assert.NotNull(actor , "actor is null");
            Assert.AreEqual(actorId , actor.GetId() , "actorId is not equal");
        }

    #endregion
    }
}