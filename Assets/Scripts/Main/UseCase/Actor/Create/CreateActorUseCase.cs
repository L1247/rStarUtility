using UseCase.Actor.Create;

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