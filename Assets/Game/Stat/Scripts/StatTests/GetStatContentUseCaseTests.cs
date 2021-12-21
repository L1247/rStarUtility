#region

using System.Collections.Generic;
using DDDCore.Usecase.CQRS;
using DDDTestFrameWork;
using NSubstitute;
using NUnit.Framework;
using Stat.Entity;
using Stat.UseCase;
using ThirtyParty.DDDCore.DDDTestFramwork;
using Zenject;

#endregion

namespace Stat.UseCaseTests
{
    [TestFixture]
    public class GetStatContentUseCaseTests : DDDUnitTestFixture
    {
    #region Test Methods

        [Test]
        public void Should_Success_When_Get_Stat_Content_With_Existing_Actor_Id()
        {
            var actorId = NewGuid();
            Container.Bind<GetStatContentUseCase>().AsSingle();
            Container.Bind<IStatRepository>().FromSubstitute();

            var repository            = Container.Resolve<IStatRepository>();
            var getStatContentUseCase = Container.Resolve<GetStatContentUseCase>();
            var input                 = new GetStatContentInput();
            var presenter             = new GetStatContentPresenter();

            Scenario("Get all stat with existing actor id")
                .Given("a existing actor id , and set stats in repository" , () =>
                {
                    input.ActorId = actorId;
                    var stats = new List<IStat>() { Substitute.For<IStat>() , Substitute.For<IStat>() };
                    repository.GetStatsByActorId(actorId).Returns(stats);
                })
                .When("get all stat" , () => { getStatContentUseCase.Execute(input , presenter); })
                .Then("the presenter is success" , () =>
                {
                    var statContentViewModel = presenter.BuildViewModel();
                    Assert.AreEqual(actorId ,          statContentViewModel.ActorId ,     "ActorId is not equal");
                    Assert.AreEqual(2 ,                statContentViewModel.Stats.Count , "satas is not equal");
                    Assert.AreEqual(ExitCode.SUCCESS , presenter.GetExitCode() ,          "ExitCode is not equal");
                });
        }

    #endregion
    }
}