using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

[Serializable]
public abstract class SocialBase
{
    public abstract int GetStars(string levelName);
    public abstract List<RecordModel> GetLeaderBoard(string levelName);

    public abstract void AddToLeaderBoard(string levelName, RecordModel model);
}

