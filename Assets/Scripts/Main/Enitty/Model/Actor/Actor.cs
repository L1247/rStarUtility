using System;

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