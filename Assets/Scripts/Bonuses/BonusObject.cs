using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;


public class BonusObject : SerializedScriptableObject
{
    public GameObject Prefab;
    [TypeFilter("GetFilteredTypeList")] 
    public BonusBehaviour Behaviour;

    public IEnumerable<Type> GetFilteredTypeList() => typeof(BonusBehaviour).Assembly.GetTypes()
            .Where(x => !x.IsAbstract)
            .Where(x => typeof(BonusBehaviour).IsAssignableFrom(x));
}
