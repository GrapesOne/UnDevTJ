using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoTapsBonus : BonusBehaviour
{
    public int times = 3;
    public override BonusBehaviour Copy() => new TwoTapsBonus {times = times};
    public override bool Action()
    {
        return --times == 0;
    }

    public override bool UpdateAction(ObjectForTapping _objectForTapping)
    {
        _objectForTapping.increase = 2;
        return false;
    }

}
