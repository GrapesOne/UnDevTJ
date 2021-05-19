using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;


public class LevelData : SerializedScriptableObject
{
    public string Name;
    public string DatasetName;
    public Sprite Background;
    public Color BackgroundColor;
    public TargetData LevelTarget;
    [TypeFilter("GetFilteredTypeList")] 
    public SocialBase Socials;
    
    public IEnumerable<Type> GetFilteredTypeList() => typeof(SocialBase).Assembly.GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => typeof(SocialBase).IsAssignableFrom(x));
}