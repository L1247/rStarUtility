using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class CreateActorUseCaseTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Should_Succeed_When_Create_Actor()
        {
            var actorRepository    = new ActorRepository();
            var createActorUseCase = new CreateActorUseCase(actorRepository);
            var input   = new CreateActorInput();
            input.PosId = "Pos 100";
            var output = new CreateActorOutput();
            createActorUseCase.Execute(input,output);
            Assert.AreEqual( "Pos 100" , actorRepository.FindById(output.ID).PosId );
        }
    }

    public class CreateActorOutput
    {
        private string _id;

        public string ID
        {
            get => _id;
            set => _id = value;
        }
    }

    public class CreateActorInput
    {
        private string _posId;

        public string PosId
        {
            get => _posId;
            set => _posId = value;
        }
    }

    public class CreateActorUseCase
    {
        private ActorRepository _repository;

        public CreateActorUseCase(ActorRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CreateActorInput input , CreateActorOutput output)
        {
            var actor = new Actor();
            actor.SetPositionId(input.PosId);
            output.ID = actor.ID;
            _repository.Save(actor);
        }
    }

    public class ActorRepository
    {
        private List<Actor> _actors = new List<Actor>();

        public Actor FindById(string id)
        {
            return _actors.Find(actor => actor.ID.Equals(id));
        }

        public void Save(Actor actor)
        {
            _actors.Add(actor);
        }
    }

    public class Actor
    {
        private string _id;
        private string _posId;

        public string PosId
        {
            get => _posId;
        }

        public string ID
        {
            get => _id;
        }


        public Actor()
        {
            _id = Guid.NewGuid().ToString();
        }

        public void SetPositionId(string posId)
        {
            _posId = posId;
        }
    }
}
