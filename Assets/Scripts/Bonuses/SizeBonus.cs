using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeBonus : BonusBehaviour
{
    public int times = 3;

    public override BonusBehaviour Copy() => new SizeBonus {times = times};

    public override bool UpdateAction(ObjectForTapping _objectForTapping)
    {
        _objectForTapping.transform.localScale = Vector3.one*2;
        return false;
    }

    public override bool Action() {
        return --times == 0;
    }
}
