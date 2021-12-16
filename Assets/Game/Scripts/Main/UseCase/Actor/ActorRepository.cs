using System.Collections.Generic;

public class ActorRepository
{
#region Private Variables

    private readonly List<Actor> actorList = new List<Actor>();

#endregion

#region Public Methods

    public Actor FindById(string id)
    {
        return actorList.Find(actor => actor.ID.Equals(id));
    }

    public void Save(Actor actor)
    {
        actorList.Add(actor);
    }

#endregion
}