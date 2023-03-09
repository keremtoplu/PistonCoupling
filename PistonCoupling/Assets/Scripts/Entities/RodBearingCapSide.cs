using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodBearingCapSide : Parts
{
    public override void MoveTargetWithAnimation()
    {
        transform.SetParent(targetTransform);
        transform.LeanMoveLocal(Vector3.zero+new Vector3(0,0,-0.000257f),2f);
    }
}
