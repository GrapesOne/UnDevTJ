using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusForTapping : ObjectForTapping
{
    public BonusObject BonusObject;
    public override void WhenTap()
    {
        GameHolder.AddBonus(BonusObject);
        Destroy(gameObject);
    }
}
