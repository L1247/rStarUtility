using NUnit.Framework;
using UseCase.Actor.Create;

namespace Tests
{
    public class CreateActorUseCaseTest
    {
    #region Test Methods

        // A Test behaves as an ordinary method
        [Test]
        public void Should_Succeed_When_Create_Actor()
        {
            var actorRepository    = new ActorRepository();
            var createActorUseCase = new CreateActorUseCase(actorRepository);
            var input              = new CreateActorInput();
            input.PosId = "Pos 100";
            var output = new CreateActorOutput();
            createActorUseCase.Execute(input , output);
            Assert.NotNull(output.ID);
            Assert.AreEqual("Pos 100" , actorRepository.FindById(output.ID).PosId);
        }

    #endregion
    }
}