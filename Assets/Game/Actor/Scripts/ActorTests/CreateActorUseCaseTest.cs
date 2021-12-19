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
using ThirtyParty.DDDCore.DDDTestFramwork;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;

#endregion

namespace Actor.Scripts.CoreTests.UseCase
{
    public class CreateActorUseCaseTest : ExtenjectUnitTestFixture
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
            var               createActorUseCase = Container.Resolve<CreateActorUseCase>();
            var               repository         = Container.Resolve<IActorRepository>();
            var               publisher          = Container.Resolve<IPublisher<IDomainEvent>>();
            Core.Entity.Actor actor              = null;
            repository.Save(Arg.Do<Core.Entity.Actor>(_ => actor = _));
            ActorCreated actorCreated = null;
            publisher.Publish(Arg.Do<ActorCreated>(e => actorCreated = e));

            var input   = new CreateActorInput();
            var output  = CqrsCommandPresenter.NewInstance();
            var actorId = NewGuid();

            Scenario("Create a actor with valid actor id")
                .Given("a valid actor id" , () => { input.Id = actorId; })
                .When("create a actor" , () => { createActorUseCase.Execute(input , output); })
                .Then("the result is success" , () =>
                {
                    Assert.AreEqual(actorId ,          output.GetId() ,       "id is not equal");
                    Assert.AreEqual(ExitCode.SUCCESS , output.GetExitCode() , "ExitCode is not equal");
                })
                .And("the repository should save actor , and id equals" , () =>
                {
                    repository.ReceivedWithAnyArgs(1).Save(null);
                    Assert.NotNull(actor , "actor is null");
                    Assert.AreEqual(actorId , actor.GetId() , "actorId is not equal");
                })
                .And("a ActorCreated event is published , and id equals" , () =>
                {
                    publisher.Received(1).Publish(Arg.Is<IDomainEvent>(domainEvent => domainEvent.GetType() == typeof(ActorCreated)));
                    Assert.AreEqual(actorId , actorCreated.ActorId , "ActorId is not equal");
                });
        }

    #endregion
    }
}