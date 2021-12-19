#region

using DDDCore.Event;
using DDDCore.Implement;
using DDDCore.Usecase.CQRS;
using DDDTestFrameWork;
using Game.Stat.Scripts.UseCase;
using MessagePipe;
using NSubstitute;
using NUnit.Framework;
using Stat.Entity.Event;
using ThirtyParty.DDDCore.DDDTestFramwork;
using ThirtyParty.DDDCore.Implement.CQRS;
using Zenject;

#endregion

namespace Stat.UseCaseTests
{
    public class CreateStatUseCaseTests : ExtenjectUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void Should_Success_When_Create_Stat()
        {
            Container.Bind<CreateStatUseCase>().AsSingle();
            Container.Bind<ISubscriber<DomainEvent>>().FromSubstitute();
            Container.Bind<IPublisher<DomainEvent>>().FromSubstitute();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            Container.Bind<IStatRepository>().FromSubstitute();

            var createStatUseCase = Container.Resolve<CreateStatUseCase>();
            var input             = new CreateStatInput();
            var output            = CqrsCommandPresenter.NewInstance();
            var repository        = Container.Resolve<IStatRepository>();
            var publisher         = Container.Resolve<IPublisher<DomainEvent>>();

            Entity.Stat stat = null;
            repository.Save(Arg.Do<Entity.Stat>(s => stat = s));
            StatCreated statCreated = null;
            publisher.Publish(Arg.Do<StatCreated>(e => statCreated = e));

            string statId = null;
            Scenario("Create a stat with valid stat id")
                .When("create a stat" , () => { createStatUseCase.Execute(input , output); })
                .Then("the repository should save stat , and id not null" , () =>
                {
                    repository.ReceivedWithAnyArgs(1).Save(null);
                    Assert.NotNull(stat , "actor is null");
                    statId = stat.GetId();
                    Assert.NotNull(statId , "stat id is null");
                })
                .And("a StatCreated event is published , and id equals" , () =>
                {
                    publisher.Received(1).Publish(Arg.Is<DomainEvent>(domainEvent => domainEvent.GetType() == typeof(StatCreated)));
                    Assert.AreEqual(statId , statCreated.StatId , "ActorId is not equal");
                })
                .And("the result is success" , () =>
                {
                    Assert.NotNull(output.GetId() , "output id is null");
                    Assert.AreEqual(statId ,           output.GetId() ,       "id is not equal");
                    Assert.AreEqual(ExitCode.SUCCESS , output.GetExitCode() , "ExitCode is not equal");
                });
        }

    #endregion
    }
}