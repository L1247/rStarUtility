#region

using DDDCore.Usecase.CQRS;
using DDDTestFrameWork;
using Game.Stat.Scripts.UseCase;
using NSubstitute;
using NUnit.Framework;
using ThirtyParty.DDDCore.DDDTestFramwork;
using ThirtyParty.DDDCore.Implement.CQRS;

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
            var         createStatUseCase = Container.Resolve<CreateStatUseCase>();
            var         input             = new CreateStatInput();
            var         output            = CqrsCommandPresenter.NewInstance();
            var         repository        = Container.Resolve<IStatRepository>();
            Entity.Stat stat              = null;
            repository.Save(Arg.Do<Entity.Stat>(_ => stat = _));

            var statId = NewGuid();
            Scenario("Create a stat with valid stat id")
                .When("create a actor" , () => { createStatUseCase.Execute(input , output); })
                .Then("the result is success" , () =>
                {
                    Assert.AreEqual(statId ,           output.GetId() ,       "id is not equal");
                    Assert.AreEqual(ExitCode.SUCCESS , output.GetExitCode() , "ExitCode is not equal");
                })
                .And("the repository should save actor , and id equals" , () =>
                {
                    repository.ReceivedWithAnyArgs(1).Save(null);
                    Assert.NotNull(stat , "actor is null");
                    // Assert.AreEqual(actorId , actor.GetId() , "actorId is not equal");
                })
                .And("a ActorCreated event is published , and id equals" , () =>
                {
                    // publisher.Received(1).Publish(Arg.Is<DomainEvent>(domainEvent => domainEvent.GetType() == typeof(ActorCreated)));
                    // Assert.AreEqual(actorId , actorCreated.ActorId , "ActorId is not equal");
                });
        }

    #endregion
    }
}