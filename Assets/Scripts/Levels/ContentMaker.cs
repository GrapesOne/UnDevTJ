using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentMaker : MonoBehaviour
{
    public GameObject Prefab;
    public Transform Content;
    public LevelPreview Preview;
    public List<LevelData> Levels;
    
    void Start()
    {
        foreach (var level in Levels)
        {
            var ob = Instantiate(Prefab, Content);
            ob.GetComponent<LevelHolder>().SetLevelData(level, Preview);
        }
        
    }
}
