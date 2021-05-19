using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveBonus : BonusBehaviour
{
    public float liveTime = 3;
    public override BonusBehaviour Copy() => new StopMoveBonus {liveTime = liveTime};
    public override bool UpdateAction(ObjectForTapping _objectForTapping)
    {
        _objectForTapping.DontDestroy = true;
        liveTime -= Time.deltaTime;
        return liveTime <= 0;
    }

    public override bool Action() => false;

}
