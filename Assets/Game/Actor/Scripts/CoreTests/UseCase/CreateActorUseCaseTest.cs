#region

using Actor.Scripts.Core.DomainEvent;
using Actor.Scripts.Core.UseCase;
using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using DDDTestFrameWork;
using MessagePipe;
using NSubstitute;
using NUnit.Framework;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;

#endregion

namespace Actor.Scripts.CoreTests.UseCase
{
    public class CreateActorUseCaseTest : ExntenjectUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void Should_Success_When_Create_Actor()
        {
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ISubscriber<IDomainEvent>>().FromSubstitute();
            Container.Bind<IPublisher<IDomainEvent>>().FromSubstitute();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            Container.Bind<IActorRepository>().FromSubstitute();
            var createActorUseCase = Container.Resolve<CreateActorUseCase>();
            var repository         = Container.Resolve<IActorRepository>();
            var publisher          = Container.Resolve<IPublisher<IDomainEvent>>();

            Core.Entity.Actor actor = null;
            repository.Save(Arg.Do<Core.Entity.Actor>(_ => actor = _));
            ActorCreated actorCreated = null;
            publisher.Publish(Arg.Do<ActorCreated>(e => actorCreated = e));

            var createActorInput = new CreateActorInput();
            var output           = CqrsCommandPresenter.NewInstance();
            var actorId          = NewGuid();
            createActorInput.Id = actorId;
            createActorUseCase.Execute(createActorInput , output);

            // the result is success
            Assert.AreEqual(actorId ,          output.GetId() ,       "id is not equal");
            Assert.AreEqual(ExitCode.SUCCESS , output.GetExitCode() , "ExitCode is not equal");

            // Assert Repository Save.
            repository.ReceivedWithAnyArgs(1).Save(null);

            // Assert Actor's id is the same.
            Assert.NotNull(actor , "actor is null");
            Assert.AreEqual(actorId , actor.GetId() , "actorId is not equal");

            // a ActorCreated event is published.
            publisher.Received(1).Publish(Arg.Is<IDomainEvent>(i => i.GetType() == typeof(ActorCreated)));
            Assert.AreEqual(actorId , actorCreated.ActorId , "ActorId is not equal");
        }

    #endregion
    }
}