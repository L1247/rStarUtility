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

namespace Actor.UseCaseTests
{
    [TestFixture]
    public class CreateActorUseCaseTest : ExtenjectUnitTestFixture
    {
    #region Test Methods

        [Test]
        [TestCase("123")]
        [TestCase(null)]
        public void Should_Success_When_Create_Actor(string inputId)
        {
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ISubscriber<DomainEvent>>().FromSubstitute();
            Container.Bind<IPublisher<DomainEvent>>().FromSubstitute();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            Container.Bind<IActorRepository>().FromSubstitute();
            var          createActorUseCase = Container.Resolve<CreateActorUseCase>();
            var          repository         = Container.Resolve<IActorRepository>();
            var          publisher          = Container.Resolve<IPublisher<DomainEvent>>();
            Entity.Actor actor              = null;
            repository.Save(Arg.Do<Entity.Actor>(a => actor = a));
            ActorCreated actorCreated = null;
            publisher.Publish(Arg.Do<ActorCreated>(e => actorCreated = e));

            var input  = new CreateActorInput();
            var output = CqrsCommandPresenter.NewInstance();

            string actorId = null;
            Scenario("Create a actor with valid actor id")
                .Given("a valid actor id" , () => { input.Id = inputId; })
                .When("create a actor" , () => { createActorUseCase.Execute(input , output); })
                .Then("the repository should save actor , and id equals" , () =>
                {
                    repository.ReceivedWithAnyArgs(1).Save(null);
                    Assert.NotNull(actor ,         "actor is null");
                    Assert.NotNull(actor.GetId() , "id is null");
                    actorId = actor.GetId();
                })
                .And("a ActorCreated event is published , and id equals" , () =>
                {
                    publisher.Received(1).Publish(Arg.Is<DomainEvent>(domainEvent => domainEvent.GetType() == typeof(ActorCreated)));
                    Assert.AreEqual(actorId , actorCreated.ActorId , "ActorId is not equal");
                })
                .And("the result is success" , () =>
                {
                    Assert.AreEqual(actorId ,          output.GetId() ,       "id is not equal");
                    Assert.AreEqual(ExitCode.SUCCESS , output.GetExitCode() , "ExitCode is not equal");
                });
        }

    #endregion
    }
}