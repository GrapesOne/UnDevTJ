using System;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEditor;
using UnityEngine;

[Serializable]
public class LocalSocial : SocialBase
{
    public TextAsset Text;
    private JSONNode nodes;
    public override int GetStars(string levelName)
    {
        if (nodes == null) nodes = JSON.Parse(Text.text);
        var level = nodes[levelName];
        return level == null ? 0 : level["stars"].AsInt;
    }

    public override List<RecordModel> GetLeaderBoard(string levelName)
    {
        if (nodes == null) nodes = JSON.Parse(Text.text);
        var level = nodes[levelName];
        if (level == null) return new List<RecordModel>();
        var leaderboard = new List<RecordModel>();
        for (var i = 0; i < level["leaderboard"].Count; i++)
        {
            leaderboard.Add(new RecordModel(
                level["leaderboard"][i]["id"].Value,
                level["leaderboard"][i]["name"].Value,
                level["leaderboard"][i]["time"].AsFloat));
        }
        
        leaderboard.Sort();
        return leaderboard;
    }

    public override void AddToLeaderBoard(string levelName, RecordModel model)
    {
        if (nodes == null) nodes = JSON.Parse(Text.text);
        var level = nodes[levelName];
        JSONNode record = new JSONObject();
        record["id"] = model.id;
        record["name"] = model.name;
        record["time"] = model.time;
        level["leaderboard"][-1] = record;
        nodes[levelName] = level;
        File.WriteAllText(AssetDatabase.GetAssetPath(Text), nodes.ToString());
        EditorUtility.SetDirty(Text);
    }
}