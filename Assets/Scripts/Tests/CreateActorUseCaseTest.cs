using System;
using System.Collections.Generic;
using NUnit.Framework;

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

    public class CreateActorOutput
    {
    #region Public Variables

        public string ID { get; set; }

    #endregion
    }

    public class CreateActorInput
    {
    #region Public Variables

        public string PosId { get; set; }

    #endregion
    }

    public class CreateActorUseCase
    {
    #region Private Variables

        private readonly ActorRepository _repository;

    #endregion

    #region Public Methods

        public void Execute(CreateActorInput input , CreateActorOutput output)
        {
            var actor = new Actor();
            actor.SetPositionId(input.PosId);
            output.ID = actor.ID;
            _repository.Save(actor);
        }

    #endregion

        public CreateActorUseCase(ActorRepository repository)
        {
            _repository = repository;
        }
    }

    public class ActorRepository
    {
    #region Private Variables

        private readonly List<Actor> _actors = new List<Actor>();

    #endregion

    #region Public Methods

        public Actor FindById(string id)
        {
            return _actors.Find(actor => actor.ID.Equals(id));
        }

        public void Save(Actor actor)
        {
            _actors.Add(actor);
        }

    #endregion
    }

    public class Actor
    {
    #region Public Variables

        public string ID { get; }

        public string PosId { get; private set; }

    #endregion

    #region Public Methods

        public void SetPositionId(string posId)
        {
            PosId = posId;
        }

    #endregion


        public Actor()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}