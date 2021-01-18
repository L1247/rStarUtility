using System.Collections.Generic;

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