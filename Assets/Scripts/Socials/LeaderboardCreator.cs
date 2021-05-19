
using UnityEngine;

public class LeaderboardCreator : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Content;

    public void CreateLeaderbodard(LevelData levelData)
    {
        foreach (Transform t in Content) Destroy(t.gameObject);
        var recordsList = levelData.Socials.GetLeaderBoard(levelData.DatasetName);
        
        foreach (var record in recordsList)
        {
            var go = Instantiate(Prefab, Content);
            go.GetComponent<RecordInfo>().SetRecord(record);
        }
    }
}
